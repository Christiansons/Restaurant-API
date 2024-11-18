using Microsoft.EntityFrameworkCore;
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

		public async Task<int> CreateCustomer(Customer customer)
		{
			await _context.Customers.AddAsync(customer);
			await _context.SaveChangesAsync();

			return customer.Id;
		}

		public async Task<Customer> GetCustomerById(int id)
		{
			//where or find?
			return await _context.Customers.Where(c => c.Id == id).FirstOrDefaultAsync();
		}

		public async Task DeleteCustomer(int id)
		{
			Customer customerToRemove = await _context.Customers.FindAsync(id);

			if (customerToRemove != null)
			{
				_context.Customers.Remove(customerToRemove);
				await _context.SaveChangesAsync();
			}
		}

		public async Task UpdateCustomer(Customer customer)
		{
			_context.Customers.Update(customer);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Customer>> GetAllCustomers()
		{
			return await _context.Customers.Include(c => c.Reservations).ToListAsync();
		}
	}
}
