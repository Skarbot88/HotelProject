namespace HotelAPI.Database.Entities;

public abstract class Availability
{
    public DateOnly Start { get; set; }
    public DateOnly End { get; set; }
    
    //Foreign Keys
    public Hotel HotelId { get; set; }
    public Room RoomId { get; set; }
}