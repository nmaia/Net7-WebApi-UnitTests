using Hotel.API.Proxy.Helpers;
using Hotel.API.Proxy.Polly.Contracts;
using Hotel.API.Proxy.RoutesMapper;
using Hotel.API.Proxy.ViewModels.Writing;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Proxy.Controllers
{
    [ApiController]
    [Route("api/proxy/bookings")]
    public class BookingsController : ControllerBase
    {
        private readonly IPolicyHandler _polly;
        private readonly ILogger<BookingsController> _logger;

        public BookingsController(IConfiguration configuration, ILogger<BookingsController> logger, IPolicyHandler polly)
        {
            _logger = logger;
            _polly = polly;
        }

        [HttpPost("")]
        public async Task<IActionResult> PostBookingAsync(BookingRegistrationViewModel model)
        {
            try
            {
                var request = HttpClientHelper.SetHttpRequest(model, HttpMethod.Post, ExternalApiRouteMapping.POST_BOOKING_URL);

                return await _polly.WrapPolicySendAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);

                return StatusCode(500, "Something went wrong.");
            }
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateBookingAsync(BookingUpdateViewModel model)
        {
            try
            {
                var request = HttpClientHelper.SetHttpRequest(model, HttpMethod.Put, ExternalApiRouteMapping.PUT_BOOKING_URL);

                return await _polly.WrapPolicySendAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);

                return StatusCode(500, "Something went wrong.");
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetBookingAsync(Guid id)
        {
            try
            {
                var request = HttpClientHelper.SetHttpRequest(id, HttpMethod.Get, ExternalApiRouteMapping.GET_BOOKING_BY_ID_URL + id);

                return await _polly.WrapPolicySendAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);

                return StatusCode(500, "Something went wrong.");
            }
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBookingsAsync()
        {
            try
            {
                var request = HttpClientHelper.SetHttpRequest(null, HttpMethod.Get, ExternalApiRouteMapping.GET_BOOKINGS_URL);

                return await _polly.WrapPolicySendAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);

                return StatusCode(500, "Something went wrong.");
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBookingAsync(Guid id)
        {
            try
            {
                var request = HttpClientHelper.SetHttpRequest(id, HttpMethod.Delete, ExternalApiRouteMapping.DELETE_BOOKING_URL + id);

                return await _polly.WrapPolicySendAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);

                return StatusCode(500, "Something went wrong.");
            }
        }
    }
}