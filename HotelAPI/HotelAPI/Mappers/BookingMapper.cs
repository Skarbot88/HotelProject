using HotelAPI.Database;
using HotelAPI.Database.Entities;

namespace HotelAPI.Mappers;

public static class BookingMapper
{
    public static Booking BookingRequestToBooking(this CreateBookingDto bookingRequest)
    {
        return new Booking
        {
            Name = bookingRequest.Name,
            Guests = bookingRequest.Guests,
            BookingNumber = Guid.NewGuid(),
            CreatedAt = bookingRequest.CreatedAt,
            StartDate = bookingRequest.StartDate,
            EndDate = bookingRequest.EndDate,
            HotelId = bookingRequest.HotelId,
            RoomId = bookingRequest.RoomId,
        };
    }

    public static BookingDto BookingEntityToBookingDto(this Booking booking)
    {
        return new BookingDto
        {
            Id = booking.Id,
            BookingNumber = booking.BookingNumber,
            Hotel = booking.Hotel.Name,
            Name = booking.Name,
            Guests = booking.Guests,
            CreatedAt = booking.CreatedAt,
            StartDate = booking.StartDate,
            EndDate = booking.EndDate,
        };
    }
}