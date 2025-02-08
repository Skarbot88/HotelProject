using HotelAPI.Database;
using HotelAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using static System.GC;

namespace HotelAPI.Repository;

public class BookingRepository : IBookingRepository, IDisposable
{
    private readonly HotelDbContext _context;
    private bool _disposed = false;

    public BookingRepository(HotelDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Hotel>> GetHotels()
    {
        return await _context.Hotels.ToListAsync();
    }

    public async Task<Hotel?> GetHotelById(int id)
    {
        return await _context.Hotels.FindAsync(id);
    }

    public async Task<Booking> CreateBooking(Booking booking)
    {
        var hotelExists = await _context.Hotels
            .AnyAsync(h => h.Id == booking.HotelId);

        if (!hotelExists)
        {
            throw new ArgumentException($"Hotel with the id = {booking.HotelId} does not exist.");
        }

        var roomExists = await _context.Rooms
            .AnyAsync(r => r.Id == booking.RoomId && r.HotelId == booking.HotelId && booking.Guests <= r.Capacity);
        
        if (!roomExists)
        {
            throw new ArgumentException($"Room with the id = {booking.RoomId} does not exist or does not belong to the specified hotel.");
        }
        
        var overlappingBookingExists = await _context.Bookings
            .AnyAsync(b => b.RoomId == booking.RoomId &&
                           b.HotelId == booking.HotelId &&
                           b.StartDate < booking.EndDate &&  
                           b.EndDate > booking.StartDate);  

        if (overlappingBookingExists)
        {
            throw new ArgumentException("There is already a booking within the requested dates for this room.");
        }
        
        await _context.Bookings.AddAsync(booking);
        await _context.SaveChangesAsync();
        return booking;
    }

    public async Task<IEnumerable<Room>> GetRoomAvailabilityByDateRange(DateOnly startDate, DateOnly endDate, int guests)
    {
        return await _context.Rooms.Where(x => x.Capacity >= guests)
            .Where(r =>
                !(_context.Bookings.Any(b => b.RoomId == r.Id && b.EndDate > startDate && b.StartDate < endDate)))
            .ToListAsync();
    }

    public async Task<Booking> GetBookingBookingNumber(Guid guid)
    {
        return await _context.Bookings.Include(b => b.Hotel).FirstOrDefaultAsync(x => x.BookingNumber == guid);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }
    
    public void Dispose()
    {
        Dispose(true);
        SuppressFinalize(this);
    }
}