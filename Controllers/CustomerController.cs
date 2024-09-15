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
		[Route("create")]
		public async Task<IActionResult> CreateCustomer(CustomerDTO dto)
		{
			if(dto == null)
			{
				return BadRequest("Cant be empty");
			}
			await _customerService.CreateCustomer(dto);
			return Ok(dto);
		}

		[HttpDelete]
		[Route("delete")]
		public async Task<IActionResult> DeleteCustomer(int id)
		{
			await _customerService.DeleteCustomer(id);
			return Ok();
		}

		[HttpGet]
		[Route("customer/{id}")]
		public async Task<ActionResult<CustomerDTO>> GetCustomerById(int id)
		{
			var customer = await _customerService.GetCustomerById(id);
			return Ok(customer);
		}

		[HttpPut]
		[Route("Customer")]
		public async Task<IActionResult> UpdateCustomer(int id, CustomerDTO dto)
		{
			await _customerService.UpdateCustomer(id, dto);
			return Ok("Updated");
		}
    }
}
