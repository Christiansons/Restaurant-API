using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_API.Models.DTOs;
using Restaurant_API.Services.IServices;

namespace Restaurant_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		//Fråga om locks? Ska man göra flera requests eller ett i backend
		private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

		[HttpGet]
		public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAllCustomers()
		{
			try
			{
				var customers = await _customerService.GetAllCustomers();
				return Ok(customers);
			}
			catch(ArgumentNullException ex) 
			{
				return BadRequest(ex.Message);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
			
		}

		[HttpPost]
		[Route("createCustomer")]
		public async Task<IActionResult> CreateCustomer([FromBody]CreateCustomerDTO dto)
		{
			if(dto == null)
			{
				return BadRequest("Cant be empty");
			}
			await _customerService.CreateCustomer(dto);
			return Ok(dto);
		}

		[HttpDelete]
		[Route("delete/{customerId}")]
		public async Task<IActionResult> DeleteCustomer(int customerId)
		{
			await _customerService.DeleteCustomer(customerId);
			return Ok();
		}

		[HttpGet("{customerId}")]
		public async Task<ActionResult<CustomerDTO>> GetCustomerById(int customerId)
		{
			var customer = await _customerService.GetCustomerById(customerId);
			return Ok(customer);
		}

		[HttpPut]
		[Route("update/{customerId}")]
		public async Task<IActionResult> UpdateCustomer(int customerId,[FromBody] CustomerDTO dto)
		{
			await _customerService.UpdateCustomer(customerId, dto);
			return Ok("Updated");
		}
    }
}
