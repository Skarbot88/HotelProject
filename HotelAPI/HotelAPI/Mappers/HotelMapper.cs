using HotelAPI.Database.Entities;
using HotelAPI.Dto.Hotel;

namespace HotelAPI.Mappers;

public static class HotelMapper
{
    public static HotelDto HotelEntityToHotelDto(this Hotel hotel)
    {
        return new HotelDto
        {
            Id = hotel.Id,
            Name = hotel.Name,
        };
    }
}