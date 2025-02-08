using HotelAPI.Database.Entities;

namespace HotelAPI.Database;

public class CreateBookingDto
{
    public string Name { get; set; }
    public int Guests { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public int HotelId { get; set; }
    public int RoomId { get; set; }
}