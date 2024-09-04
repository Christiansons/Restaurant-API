using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_API.Models.DTOs;
using Restaurant_API.Services;

namespace Restaurant_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuController : ControllerBase
	{
		private readonly MenuService _menuService;
        public MenuController(MenuService menuService)
        {
            this._menuService = menuService;
        }

        [HttpGet]
		[Route("Menu")]
		public async Task<ActionResult<IEnumerable<DishDTO>>> Menu()
		{
			var dishes = await _menuService.GetAllDishes();
			if(dishes == null)
			{
				return NotFound("Inga rätter tillagda");
			}

			return Ok(dishes);
		}

		[HttpPost]
		[Route("Menu/AddDish")]
		public async Task<IActionResult> AddDish(DishDTO dish)
		{
			if(dish == null)
			{
				return BadRequest("Dish data cannot be empty.");
			}

			
		}

		[HttpGet]
		[Route("Menu/FindItemById")]
		public async Task<>
	}
}
