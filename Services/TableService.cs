using Restaurant_API.Models;
using Restaurant_API.Models.DTOs;
using Restaurant_API.Models.DTOs.CreateDTOs;
using Restaurant_API.Repository.IRepository;
using Restaurant_API.Services.IServices;

namespace Restaurant_API.Services
{
	public class TableService : ITableService
	{
		//Inject repository
		private readonly ITableRepository _tableRepo;
        public TableService(ITableRepository tableRepository)
        {
            _tableRepo = tableRepository;
        }


        public async Task CreateTable(CreateTableDTO dto)
		{
			try
			{
				await _tableRepo.CreateTable(new Table
				{
					TableNumber = dto.TableNr,
					Seats = dto.Seats,
				});
			} catch (Exception)
			{
				return;
			}
			
		}

		public async Task DeleteTable(int id)
		{
			if(id < 0)
			{
				throw new Exception();
			}

			Table table = await _tableRepo.GetTableById(id);

			if(table == null)
			{
				throw new NullReferenceException();
			}

			await _tableRepo.DeleteTable(table);
		}

		public async Task<IEnumerable<TableDTO>> GetAllTables()
		{
			var tables = await _tableRepo.GetAllTables();

			return tables.Select(t=> new TableDTO
			{
				tableId = t.TableId,
				Seats=t.Seats,
				TableNr = t.TableNumber
			}).ToList();
		}

		public async Task<TableDTO> GetTableByTableNr(int id)
		{
			try
			{
				var table = await _tableRepo.GetTableById(id);
				return new TableDTO
				{
					Seats = table.Seats,
					TableNr = table.TableNumber
				};
			}
			catch (Exception)
			{
				return null;
			}
		}

		//Kolla med aldor bool?
		public async Task<bool> UpdateTable(int tableId, TableDTO dto)
		{
			try
			{
				var table = await _tableRepo.GetTableById(tableId);
				table.Seats = dto.Seats;
				table.TableNumber = dto.TableNr;
				await _tableRepo.UpdateTable(table);
				return true;
			} catch (Exception)
			{
				return false;
			}
		}
	}
}
