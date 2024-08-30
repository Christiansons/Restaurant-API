using Restaurant_API.Models;
using Restaurant_API.Models.DTOs;
using Restaurant_API.Repository.IRepository;
using Restaurant_API.Services.IServices;

namespace Restaurant_API.Services
{
	public class MenuService : IMenuService
	{
		private readonly IMenuRepository _menuRepo;
        public MenuService(IMenuRepository menuRepo)
        {
            _menuRepo = menuRepo;
        }

        public async Task<DishDTO> CreateDish(DishDTO dto)
		{
			if(dto == null)
			{
				return null;
			}

			await _menuRepo.CreateDish(new Dish
			{
				DishName = dto.DishName,
				PriceInSek = dto.PriceInSek,
				IsAvailable = dto.IsAvailable,
			});

			return dto;
		}

		public async Task<DishDTO> UpdateDish(int oldDishId, DishDTO NewDishdto)
		{
			Dish oldDish = await _menuRepo.FindDishById(oldDishId);
			if(oldDish == null)
			{
				return null;
			}
		}

		public async Task DeleteDish(int id)
		{
			await _menuRepo.DeleteDish(id); //Try catch in controller
		}
	}
}
