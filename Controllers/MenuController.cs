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
		public async Task<ActionResult<IEnumerable<DishDTO>>> GetAllDishes()
		{
			//Denna eller table getAll?
			var dishes = await _menuService.GetMenu();
			if (dishes == null)
			{
				return NotFound("Inga rätter tillagda");
			}
			return Ok(dishes);
		}

		[HttpDelete]
		[Route("delete/{dishId}")]
		public async Task<IActionResult> DeleteDish(int dishId)
		{
			await _menuService.DeleteDish(dishId);
			return Ok("Dish deleted");
		}

		[HttpPost]
		[Route("createDish")]
		public async Task<IActionResult> CreateDish([FromBody] DishDTO dish)
		{
			//testa allt här eller som på reservation?
			if (dish == null)
			{
				return BadRequest("Dish data cannot be empty.");
			}

			try
			{
				await _menuService.CreateDish(dish);
				return Ok("Dish created");
			}
			catch (ArgumentNullException ex)
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
		public async Task<IActionResult> UpdateDish(int dishId, [FromBody] DishDTO dto)
		{
			if (dto == null)
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

		[HttpGet("{dishId}")]
		public async Task<ActionResult<DishDTO>> GetDishById(int dishId)
		{
			var dish = await _menuService.GetDishById(dishId);
			if(dish == null)
			{
				return NotFound();
			}
			return Ok(dish);
		}
	}
}
