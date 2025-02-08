using HotelAPI.Database;
using HotelAPI.Database.Entities;
using HotelAPI.Dto;

namespace HotelAPI.Mappers;

public static class RoomMapper
{
    public static RoomDto RoomEntityToRoomDto(this Room room)
    {
        return new RoomDto()
        {
            Type  = room.Type.ToString(),
            Capacity = room.Capacity,
            RoomNumber = room.RoomNumber,
            HotelId = room.HotelId
        };
    }
}