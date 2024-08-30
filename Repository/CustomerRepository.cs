using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

		public async Task<Customer> CreateCustomer(Customer customer)
		{
			await _context.Customers.AddAsync(customer);
			await _context.SaveChangesAsync();
			return customer;
		}

		public async Task DeleteTable(Customer customer)
		{
			Customer customerToRemove = await _context.Customers.FindAsync(customer);

			if (customerToRemove != null)
			{
				_context.Customers.Remove(customer);
				await _context.SaveChangesAsync();
			}
		}

		public async Task UpdateTable(Customer customer)
		{
			_context.Customers.Update(customer);
			await _context.SaveChangesAsync();
		}
	}
}
