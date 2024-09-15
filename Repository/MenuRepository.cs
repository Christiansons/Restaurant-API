using Microsoft.EntityFrameworkCore;
using Restaurant_API.Data;
using Restaurant_API.Models;
using Restaurant_API.Models.DTOs;
using Restaurant_API.Repository.IRepository;

namespace Restaurant_API.Repository 
{
	public class MenuRepository : IMenuRepository
	{
		private readonly RestaurantContext _context;
        public MenuRepository(RestaurantContext context)
        {
            _context = context;
        }

		public async Task<Dish> GetDishById(int id)
		{
			return await _context.Menu.FindAsync(id);
		}

        public async Task<Dish> CreateDish(Dish dish)
		{
			await _context.Menu.AddAsync(dish);
			await _context.SaveChangesAsync();
			return dish;
		}

		public async Task DeleteDish(int id)
		{
			Dish dishToRemove = await _context.Menu.FindAsync(id);

			if (dishToRemove != null)
			{
				_context.Menu.Remove(dishToRemove);
				await _context.SaveChangesAsync();
			}
		}

		public async Task UpdateDish(Dish dish)
		{
			_context.Menu.Update(dish);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Dish>> GetAllDishes()
		{
			return await _context.Menu.ToListAsync();
		}
	}
}
