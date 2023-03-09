using Hotel.API.Proxy.Helpers;
using Hotel.API.Proxy.Polly.Contracts;
using Hotel.API.Proxy.RoutesMapper;
using Hotel.API.Proxy.ViewModels.Writing;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Proxy.Controllers
{
    [ApiController]
    [Route("api/proxy/rooms")]
    public class RoomsController : ControllerBase
    {
        private readonly IPolicyHandler _polly;
        private readonly ILogger<RoomsController> _logger;

        public RoomsController(IConfiguration configuration, ILogger<RoomsController> logger, IPolicyHandler polly)
        {
            _logger = logger;
            _polly = polly;
        }

        [HttpPost("")]
        public async Task<IActionResult> PostRoomAsync(RoomRegistrationViewModel model)
        {
            try
            {
                var request = HttpClientHelper.SetHttpRequest(model, HttpMethod.Post, ExternalApiRouteMapping.POST_ROOM_URL);

                return await _polly.WrapPolicySendAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);

                return StatusCode(500, "Something went wrong.");
            }
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateRoomAsync(RoomUpdateViewModel model)
        {
            try
            {
                var request = HttpClientHelper.SetHttpRequest(model, HttpMethod.Put, ExternalApiRouteMapping.PUT_ROOM_URL);

                return await _polly.WrapPolicySendAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);

                return StatusCode(500, "Something went wrong.");
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetRoomByIDAsync(Guid id)
        {
            try
            {
                var request = HttpClientHelper.SetHttpRequest(id, HttpMethod.Get, ExternalApiRouteMapping.GET_ROOM_BY_ID_URL + id);

                return await _polly.WrapPolicySendAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);

                return StatusCode(500, "Something went wrong.");
            }
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllRoomsAsync()
        {
            try
            {
                var request = HttpClientHelper.SetHttpRequest(null, HttpMethod.Get, ExternalApiRouteMapping.GET_ROOMS_URL);

                return await _polly.WrapPolicySendAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);

                return StatusCode(500, "Something went wrong.");
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteRoomAsync(Guid id)
        {
            try
            {
                var request = HttpClientHelper.SetHttpRequest(id, HttpMethod.Delete, ExternalApiRouteMapping.DELETE_ROOM_URL + id);

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