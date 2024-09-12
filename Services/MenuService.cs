﻿using Restaurant_API.Models;
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

        public async Task CreateDish(DishDTO dto)
		{
			ArgumentNullException.ThrowIfNull(dto);

			await _menuRepo.CreateDish(new Dish
			{
				DishName = dto.DishName,
				PriceInSek = dto.PriceInSek,
				IsAvailable = dto.IsAvailable,
			});
		}

		public async Task UpdateDish(int oldDishId, DishDTO NewDishdto)
		{
			Dish dish = await _menuRepo.FindDishById(oldDishId);
			if (dish == null)
			{
				return;
			}

			await _menuRepo.UpdateDish(oldDishId, new Dish
			{
				DishName = NewDishdto.DishName,
				IsAvailable = NewDishdto.IsAvailable,
				PriceInSek = NewDishdto.PriceInSek
			});
		}

		public async Task DeleteDish(int id)
		{
			await _menuRepo.DeleteDish(id); //Try catch in controller
		}

		public async Task<IEnumerable<DishDTO>> GetAllDishes()
		{
			var dishes = await _menuRepo.GetAllDishes();
			var dishesDto =  dishes.Select(d => new DishDTO
			{
				DishName = d.DishName,
				IsAvailable = d.IsAvailable,
				PriceInSek = d.PriceInSek
			}).ToList();

			return dishesDto;
		}

		
	}
}
