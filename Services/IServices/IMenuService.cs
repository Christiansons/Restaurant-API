using Restaurant_API.Models.DTOs;

namespace Restaurant_API.Services.IServices
{
	public interface IMenuService
	{
		public Task CreateDish(DishDTO dishDTO);
		public Task UpdateDish(int id, DishDTO dishDTO);
		public Task DeleteDish(DishDTO dishDTO);
		public Task<DishDTO> GetDishById(int id);
		public Task<IEnumerable<DishDTO>> GetMenu();
	}
}
