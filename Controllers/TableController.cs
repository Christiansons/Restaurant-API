using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_API.Models.DTOs;
using Restaurant_API.Services;
using Restaurant_API.Services.IServices;

namespace Restaurant_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TableController : ControllerBase
	{
		private readonly ITableService _tableService;
        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

		[HttpPost]
		[Route("addTable/{seats}")] //När det är en sak som ska in, ändå från body? Känns logiskt tvärtom dock
		public async Task<IActionResult> CreateTable(int seats)
		{
			if (seats < 1)
			{
				return BadRequest("Cant be empty table");
			}

			await _tableService.CreateTable(seats);
			return Ok("Table created");
		}

		[HttpDelete]
		[Route("delete/{id}")]
		public async Task<IActionResult> DeleteTable(int id)
		{
			await _tableService.DeleteTable(id);
			return Ok("Table deleted");
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<ActionResult<TableDTO>> GetTableById(int id)
		{
			var table = await _tableService.GetTableByTableNr(id);
			return Ok(table);
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<TableDTO>>> GetAllTables()
		{
			var tables = await _tableService.GetAllTables();
			var tablesDto = tables.Select(t => new TableDTO { Seats = t.Seats, TableNr = t.TableNr }).ToList();

			return Ok(tablesDto);
		}

		[HttpPut]
		[Route("update/{id}")]
		public async Task<IActionResult> UpdateTable(int id, [FromBody]TableDTO dto)
		{
			await _tableService.UpdateTable(dto);
			return Ok("Table updated");
		}
    }
}
