using Restaurant_API.Data;
using Restaurant_API.Models;
using Restaurant_API.Repository.IRepository;

namespace Restaurant_API.Repository
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly RestaurantContext _context;
        public CustomerRepository(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<Customer> SaveCustomer(Customer customer)
		{
			await _context.Customers.AddAsync(customer);
			await _context.SaveChangesAsync();
			return customer;
		}
	}
}
