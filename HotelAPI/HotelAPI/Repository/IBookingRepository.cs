using HotelAPI.Database;
using HotelAPI.Database.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HotelAPI.Repository;

public interface IBookingRepository : IDisposable
{
    Task<IEnumerable<Hotel>> GetHotels();
    Task<Hotel?> GetHotelById(int id);
    Task<Booking> CreateBooking(Booking booking);
    Task<Booking> GetBookingBookingNumber(Guid guid);
    Task<IEnumerable<Room>> GetRoomAvailabilityByDateRange(DateOnly from, DateOnly to, int guests);
 }