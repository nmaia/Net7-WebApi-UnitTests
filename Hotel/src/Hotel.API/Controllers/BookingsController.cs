using Hotel.Application.Contracts;
using Hotel.Application.ViewModels.Writing;
using Hotel.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingApplicationService _bookingApplicationService;
        private readonly IRoomApplicationService _roomApplicationService;
        private readonly ILogger<BookingsController> _logger;

        public BookingsController(ILogger<BookingsController> logger, IBookingApplicationService bookingApplicationService, IRoomApplicationService roomApplicationService)
        {
            _logger = logger;
            _bookingApplicationService = bookingApplicationService;
            _roomApplicationService = roomApplicationService;
        }

        /// <summary>
        /// Create a new booking
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // todo: would this endpoint makes more sense in the hotels controller?
        [HttpPost("")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PostBookingAsync(BookingRegistrationViewModel model)
        {
            try
            {
                var room = await _roomApplicationService.GetRoomByIDAsync(model.RoomID);

                if (room == null) return NotFound("The room you're trying to book was not found.");

                if (!room.IsAvailable) return BadRequest($"The room {room.Number} is unavailable, chose another one.");
                
                var booking = await _bookingApplicationService.CreateBookingAsync(model);

                if (booking == null) return BadRequest($"The room {room.Number} couldn't be booked. Check the room availability or the booking data.");

                return Created($"api/bookings/{booking.BookingID}", booking);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);

                return StatusCode(500, "Something went wrong.");
            }
        }

        /// <summary>
        /// Delete a booking from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteBookingAsync(Guid id)
        {
            try
            {
                var booking = await _bookingApplicationService.GetBookingByIDAsync(id);

                if (booking == null) return NotFound($"There is no booking with the ID: {id}");

                if (!await _bookingApplicationService.DeleteBookingAsync(id)) return BadRequest();

                return Ok($"The booking ({booking.BookingID}) has been deleted.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);

                return StatusCode(500, "Something went wrong.");
            }
        }

        /// <summary>
        /// Update booking data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateBookingAsync(BookingUpdateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var wasBookingUpdated = await _bookingApplicationService.UpdateBookingAsync(model);

                    if (!wasBookingUpdated) return BadRequest($"The booking {model.BookingID} couldn't be updated. Check the the booking data.");                    

                    return Ok(model);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);

                return StatusCode(500, "Something went wrong.");
            }
        }

        /// <summary>
        /// Get a booking by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetBookingAsync(Guid id)
        {
            try
            {
                var booking = await _bookingApplicationService.GetBookingByIDAsync(id);

                if (booking == null) return NoContent();

                return Ok(booking);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);

                return StatusCode(500, "Something went wrong.");
            }
        }

        /// <summary>
        /// Get all bookings
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllBookingsAsync()
        {
            try
            {
                var response = await _bookingApplicationService.GetAllBookingsAsync();

                if (response == null) return NoContent();

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);

                return StatusCode(500, "Something went wrong.");
            }
        }
    }
}