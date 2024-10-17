using Restaurant_API.Models.DTOs;
using Restaurant_API.Models.DTOs.CreateDTOs;

namespace Restaurant_API.Services.IServices
{
    public interface ICustomerService
	{
		public Task CreateCustomer(CreateCustomerDTO customerDTO);
		public Task UpdateCustomer(int id, CustomerDTO customerDTO);
		public Task DeleteCustomer(int id);
		public Task<CustomerDTO> GetCustomerById(int id);
		public Task<IEnumerable<CustomerDTO>> GetAllCustomers();
	}
}
