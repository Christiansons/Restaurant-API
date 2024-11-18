using Restaurant_API.Models;

namespace Restaurant_API.Repository.IRepository
{
	public interface ICustomerRepository
	{
		public Task<int> CreateCustomer(Customer customer);
		public Task DeleteCustomer(int id);
		public Task UpdateCustomer(Customer customer);
		public Task<Customer> GetCustomerById(int id);
		Task<IEnumerable<Customer>> GetAllCustomers();
	}
}
