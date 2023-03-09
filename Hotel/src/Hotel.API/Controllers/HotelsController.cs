using Hotel.Application.Contracts;
using Hotel.Application.ViewModels.Writing;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{
    [ApiController]
    [Route("api/hotels")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelApplicationService _hotelApplicationService;
        private readonly ILogger<HotelsController> _logger;

        public HotelsController(ILogger<HotelsController> logger, IHotelApplicationService hotelApplicationService)
        {
            _logger = logger;
            _hotelApplicationService = hotelApplicationService;
        }

        /// <summary>
        /// Creates a new hotel
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PostHotelAsync(HotelRegistrationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var hotel = await _hotelApplicationService.CreateHotelAsync(model);

                    if (hotel == null) return BadRequest();

                    return Created($"api/hotels/{hotel.HotelID}", hotel);
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
        /// Update an existing hotel
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateHotelAsync(HotelUpdateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!await _hotelApplicationService.UpdateHotelAsync(model)) return BadRequest();

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
        /// Get a hotel by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetHotelByIDAsync(Guid id)
        {
            try
            {
                var response = await _hotelApplicationService.GetHotelByIDAsync(id);

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
        /// Get all hotels from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllHotelsAsync()
        {
            try
            {
                var response = await _hotelApplicationService.GetAllHotelsAsync();

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
        /// Delete an existing hotel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteHotelAsync(Guid id)
        {
            try
            {
                var hotel = await _hotelApplicationService.GetHotelByIDAsync(id);

                if (hotel == null) return NotFound($"There is no hotel with the ID: {id}");

                if (!await _hotelApplicationService.DeleteHotelAsync(id)) return BadRequest();

                return Ok($"The hotel {hotel.Name} has been deleted.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);

                return StatusCode(500, "Something went wrong.");
            }
        }
    }
}