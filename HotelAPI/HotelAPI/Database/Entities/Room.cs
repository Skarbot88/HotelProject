namespace HotelAPI.Database.Entities;

public class Room
{
    public int Id { get; set; }
    public RoomType Type { get; set; }
    public int Capacity { get; set; }
    public int RoomNumber { get; set; }
    
    //Foreign Key
    public int HotelId { get; set; }
    //Navigation properties 
    public Hotel Hotel { get; set; }
    public ICollection<Booking> Bookings { get; set; }
}