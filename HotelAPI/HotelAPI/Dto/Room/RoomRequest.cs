namespace HotelAPI.Database.Entities;

public class RoomRequest
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int Guests { get; set; }
}