namespace HotelAPI.Database;

public class BookingDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Guid BookingNumber { get; set; }
    public string Hotel { get; set; }
    public int Guests { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public DateTime CreatedAt { get; set; }
}