using Hotel.Application.Contracts;
using Hotel.Application.ViewModels.Writing;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerApplicationService _customerApplicationService;
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ILogger<CustomersController> logger, ICustomerApplicationService customerApplicationService)
        {
            _logger = logger;
            _customerApplicationService = customerApplicationService;
        }

        /// <summary>
        /// Create a new Customer
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PostCustomerAsync(CustomerRegistrationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var customer = await _customerApplicationService.CreateCustomerAsync(model);

                    if (customer != null) return Created($"api/customers/{customer.CustomerID}", customer);

                    return BadRequest();
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
        /// Update Customer info
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateCustomerAsync(CustomerUpdateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!await _customerApplicationService.UpdateCustomerAsync(model)) return BadRequest();

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
        /// Get a Customer by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetCustomerByIDAsync(Guid id)
        {
            try
            {
                var response = await _customerApplicationService.GetCustomerByIDAsync(id);

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
        /// Get all Customers
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllCustomersAsync()
        {
            try
            {
                var response = await _customerApplicationService.GetAllCustomersAsync();

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
        /// Delete a Customer from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteCustomerAsync(Guid id)
        {
            try
            {
                var customer = await _customerApplicationService.GetCustomerByIDAsync(id);

                if (customer == null) return NotFound($"There is no customer with the ID: {id}");

                if (!await _customerApplicationService.DeleteCustomerAsync(id)) return BadRequest();

                return Ok($"The customer {customer.Name} has been deleted.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);

                return StatusCode(500, "Something went wrong.");
            }
        }
    }
}