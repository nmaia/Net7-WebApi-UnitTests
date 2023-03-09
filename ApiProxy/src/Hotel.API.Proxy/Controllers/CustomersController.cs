using Hotel.API.Proxy.Helpers;
using Hotel.API.Proxy.Polly.Contracts;
using Hotel.API.Proxy.RoutesMapper;
using Hotel.API.Proxy.ViewModels.Writing;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Proxy.Controllers
{
    [ApiController]
    [Route("api/proxy/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly IPolicyHandler _polly;
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(IConfiguration configuration, ILogger<CustomersController> logger, IPolicyHandler polly)
        {
            _logger = logger;
            _polly = polly;
        }

        [HttpPost("")]
        public async Task<IActionResult> PostCustomerAsync(CustomerRegistrationViewModel model)
        {
            try
            {
                var request = HttpClientHelper.SetHttpRequest(model, HttpMethod.Post, ExternalApiRouteMapping.POST_CUSTOMER_URL);

                return await _polly.WrapPolicySendAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);

                return StatusCode(500, "Something went wrong.");
            }
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateCustomerAsync(CustomerUpdateViewModel model)
        {
            try
            {
                var request = HttpClientHelper.SetHttpRequest(model, HttpMethod.Put, ExternalApiRouteMapping.PUT_CUSTOMER_URL);

                return await _polly.WrapPolicySendAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);

                return StatusCode(500, "Something went wrong.");
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCustomerByIDAsync(Guid id)
        {
            try
            {
                var request = HttpClientHelper.SetHttpRequest(id, HttpMethod.Get, ExternalApiRouteMapping.GET_CUSTOMER_BY_ID_URL + id);

                return await _polly.WrapPolicySendAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);

                return StatusCode(500, "Something went wrong.");
            }
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCustomersAsync()
        {
            try
            {
                var request = HttpClientHelper.SetHttpRequest(null, HttpMethod.Get, ExternalApiRouteMapping.GET_CUSTOMERS_URL);

                return await _polly.WrapPolicySendAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);

                return StatusCode(500, "Something went wrong.");
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCustomerAsync(Guid id)
        {
            try
            {
                var request = HttpClientHelper.SetHttpRequest(id, HttpMethod.Delete, ExternalApiRouteMapping.DELETE_CUSTOMER_URL + id);

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