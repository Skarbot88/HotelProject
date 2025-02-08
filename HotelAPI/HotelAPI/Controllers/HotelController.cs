using HotelAPI.Database;
using HotelAPI.Database.Entities;
using HotelAPI.Dto;
using HotelAPI.Mappers;
using HotelAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;

        public HotelController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotel()
        {
            var result = await _bookingRepository.GetHotels();
            return Ok(result.Select(x => x.HotelEntityToHotelDto()));
        }
        
        [HttpGet]
        [Route("get/{id:int}")]
        public async Task<ActionResult<Hotel>> GetHotelById(int id)
        {
            var result = await _bookingRepository.GetHotelById(id);
            return Ok(result.HotelEntityToHotelDto());
        }
        
        [HttpPost]
        [Route("make-booking")]
        public async Task<ActionResult<Hotel>> MakeBooking([FromBody]CreateBookingDto createBookingDto)
        {
            try
            {
                var bookingModel = createBookingDto.BookingRequestToBooking();
                var result = await _bookingRepository.CreateBooking(bookingModel);
                return Ok(result.BookingEntityToBookingDto());
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet]
        [Route("get-booking/{guid:guid}")]
        public async Task<ActionResult<BookingDto>> GetBooking(Guid guid)
        {
            try
            {
                var result = await _bookingRepository.GetBookingBookingNumber(guid);
                return Ok(result.BookingEntityToBookingDto());
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet]
        [Route("get-available-rooms")]
        public async Task<ActionResult<IEnumerable<RoomDto>>> FindAvailableRooms([FromQuery] RoomRequest roomRequest)
        {
            try
            {
                var result = await _bookingRepository.GetRoomAvailabilityByDateRange(roomRequest.StartDate, roomRequest.EndDate, roomRequest.Guests);
                return Ok(result.Select(x => x.RoomEntityToRoomDto()));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
