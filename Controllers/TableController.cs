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
		[Route("createTable/{seats}")] //När det är en sak som ska in, ändå från body? Känns logiskt tvärtom dock
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
		[Route("delete/{tableId}")]
		public async Task<IActionResult> DeleteTable(int tableId)
		{
			await _tableService.DeleteTable(tableId);
			return Ok("Table deleted");
		}

		[HttpGet]
		[Route("{tableId}")]
		public async Task<ActionResult<TableDTO>> GetTableById(int tableId)
		{
			var table = await _tableService.GetTableByTableNr(tableId);
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
		[Route("update/{tableId}")]
		public async Task<IActionResult> UpdateTable(int tableId, [FromBody]int seats)
		{
			await _tableService.UpdateTable(tableId, seats);
			return Ok("Table updated");
		}
    }
}
