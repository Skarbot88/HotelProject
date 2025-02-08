using HotelAPI.Database.Entities;

namespace HotelAPI.Database;

public interface IDatabaseHandler
{
    Task<IEnumerable<Hotel>> GetHotels();
    Task<Hotel> GetHotelById(int id);
    Task<Guid> MakeBooking(CreateBookingDto createBookingDto);
}