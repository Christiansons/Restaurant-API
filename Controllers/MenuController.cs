using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_API.Models.DTOs;
using Restaurant_API.Services;
using Restaurant_API.Services.IServices;

namespace Restaurant_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuController : ControllerBase
	{
		private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            this._menuService = menuService;
        }

        [HttpGet]
		[Route("")]
		public async Task<ActionResult<IEnumerable<DishDTO>>> GetMenu()
		{
			var dishes = await _menuService.GetMenu();
			if(dishes == null)
			{
				return NotFound("Inga rätter tillagda");
			}

			return Ok(dishes);
		}

		[HttpPost]
		[Route("add")]
		public async Task<IActionResult> AddDish(DishDTO dish)
		{
			if(dish == null)
			{
				return BadRequest("Dish data cannot be empty.");
			}

			try
			{
				await _menuService.CreateDish(dish);
				return Ok("Dish created");
			}
			catch(ArgumentNullException ex)
			{
				return BadRequest("Error creating dish");
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPut]
		[Route("update/{dishId}")]
		public async Task<IActionResult> UpdateDish(int dishId, [FromBody]DishDTO dto)
		{
			if(dto == null)
			{
				return BadRequest("Dish data cannot be empty");
			}
			try
			{
				await _menuService.UpdateDish(dishId, dto);
				return Ok("Dish updated");
			}
			catch (ArgumentNullException ex)
			{
				return BadRequest("Error updating dish");
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet]
		[Route("dish/{id}")]
		public async Task<ActionResult<DishDTO>> GetDishById(int id)
		{
			var dish = _menuService.GetDishById(id);
			return Ok(dish);
		}
	}
}
