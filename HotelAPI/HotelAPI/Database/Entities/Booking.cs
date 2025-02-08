namespace HotelAPI.Database.Entities;

public class Booking
{
    public int Id { get; set; }
    public Guid BookingNumber { get; set; } 
    public string Name { get; set; }
    public int Guests { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public DateTime CreatedAt { get; set; }
    
    //Foreign Key Contraints 
    public int HotelId { get; set; }
    public int RoomId { get; set; }
    
    //Navigation Properties 
    public Hotel Hotel { get; set; }
    public Room Room { get; set; }
}