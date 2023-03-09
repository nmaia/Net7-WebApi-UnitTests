using Hotel.Application.Contracts;
using Hotel.Application.ViewModels.Writing;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{
    [ApiController]
    [Route("api/rooms")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomApplicationService _roomApplicationService;
        private readonly IHotelApplicationService _hotelApplicationService;
        private readonly ILogger<RoomsController> _logger;

        public RoomsController(ILogger<RoomsController> logger, IRoomApplicationService roomApplicationService, IHotelApplicationService hotelApplicationService)
        {
            _logger = logger;
            _roomApplicationService = roomApplicationService;
            _hotelApplicationService = hotelApplicationService;
        }

        /// <summary>
        /// Create a new room for the hotel
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PostRoomAsync(RoomRegistrationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var room = await _roomApplicationService.CreateRoomAsync(model);

                    if (room == null) return BadRequest();

                    return Created($"api/rooms/{room.RoomID}", room);
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
        /// Update the room info
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateRoomAsync(RoomUpdateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!await _roomApplicationService.UpdateRoomAsync(model)) return BadRequest();

                    return Ok();
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
        /// Get a specific room by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetRoomByIDAsync(Guid id)
        {
            try
            {
                var response = await _roomApplicationService.GetRoomByIDAsync(id);

                if (response == null) return NoContent();

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);

                return StatusCode(500, "Something went wrong.");
            }
        }

        /// <summary>
        /// Get all rooms
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllRoomsAsync()
        {
            try
            {
                var response = await _roomApplicationService.GetAllRoomsAsync();

                if (response == null) return NoContent();

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);

                return StatusCode(500, "Something went wrong.");
            }
        }

        /// <summary>
        /// Delete room database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteRoomAsync(Guid id)
        {
            try
            {
                var room = await _roomApplicationService.GetRoomByIDAsync(id);

                if (room == null) return NotFound($"There is no room with this ID: {id}");

                var hotel = await _hotelApplicationService.GetHotelByIDAsync(room.HotelID);

                if (!await _roomApplicationService.DeleteRoomAsync(id)) return BadRequest();

                return Ok($"The room {room.Number} from {hotel.Name} has been deleted.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);

                return StatusCode(500, "Something went wrong.");
            }
        }
    }
}