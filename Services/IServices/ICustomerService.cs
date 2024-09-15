using Restaurant_API.Models.DTOs;

namespace Restaurant_API.Services.IServices
{
	public interface ICustomerService
	{
		public Task CreateCustomer(CustomerDTO customerDTO);
		public Task UpdateCustomer(int id, CustomerDTO customerDTO);
		public Task DeleteCustomer(int id);
		public Task<CustomerDTO> GetCustomerById(int id);
		public Task<IEnumerable<CustomerDTO>> GetAllCustomers();
	}
}
