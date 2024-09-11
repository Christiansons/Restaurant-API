using Restaurant_API.Models;
using Restaurant_API.Models.DTOs;
using Restaurant_API.Repository.IRepository;
using Restaurant_API.Services.IServices;

namespace Restaurant_API.Services
{
	public class TableService : ITableService
	{
		private readonly ITableRepository _tableRepo;
        public TableService(ITableRepository tableRepository)
        {
            _tableRepo = tableRepository;
        }

        public async Task CreateTable(int seats)
		{
			try
			{
				await _tableRepo.SaveTable(new Table
				{
					Seats = seats
				});
			} catch (Exception ex)
			{
				return;
			}
			
		}

		public async Task DeleteTable(int id)
		{
			Table table = await _tableRepo.GetTableById(id);
			await _tableRepo.RemoveTable(table);
		}

		public async Task<IEnumerable<TableDTO>> GetAllTables()
		{
			var tables = await _tableRepo.GetAllTables();

			return tables.Select(t=> new TableDTO
			{
				Seats=t.Seats,
				TableNr = t.TableNumber
			}).ToList();
		}

		public async Task<TableDTO> GetTableByTableNr(int id)
		{
			var table = await _tableRepo.GetTableById(id);
			return new TableDTO
			{
				Seats = table.Seats,
				TableNr = table.TableNumber
			};
		}

		public async Task UpdateTable(TableDTO tableDto)
		{
			await _tableRepo.UpdateTable(new Table { TableNumber = tableDto.TableNr, Seats = tableDto.Seats });
		}
	}
}
