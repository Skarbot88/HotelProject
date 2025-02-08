using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Database.Entities;

public class Hotel 
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    [MaxLength(6)]
    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}