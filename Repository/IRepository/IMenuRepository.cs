using Restaurant_API.Models;
using Restaurant_API.Models.DTOs;

namespace Restaurant_API.Repository.IRepository
{
	public interface IMenuRepository
	{
		public Task<Dish> CreateDish(Dish dish);
		public Task DeleteDish(int id);
		public Task UpdateDish(Dish dish);
		public Task<Dish> FindDishById(int id);
		Task<IEnumerable<Dish>> GetAllDishes();
	}
}
