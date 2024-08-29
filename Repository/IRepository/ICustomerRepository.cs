using Restaurant_API.Models;

namespace Restaurant_API.Repository.IRepository
{
	public interface ICustomerRepository
	{
		public Task<Customer> SaveCustomer(Customer customer);
	}
}
