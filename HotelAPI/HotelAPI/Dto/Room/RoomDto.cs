using HotelAPI.Database.Entities;

namespace HotelAPI.Dto;

public class RoomDto
{
    public string Type { get; set; }
    public int Capacity { get; set; }
    public int RoomNumber { get; set; }
    public int HotelId { get; set; }
}