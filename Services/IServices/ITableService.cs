using Restaurant_API.Models.DTOs;
using Restaurant_API.Models.DTOs.CreateDTOs;

namespace Restaurant_API.Services.IServices
{
	public interface ITableService
	{
		public Task CreateTable(CreateTableDTO dto);
		public Task<bool> UpdateTable(int id, TableDTO dto);
		public Task DeleteTable(int id);
		public Task<TableDTO> GetTableByTableNr(int id);
		public Task<IEnumerable<TableDTO>> GetAllTables();
		public Task<IEnumerable<AvailableTimeForDateDTO>> GetAvialableTablesForDate(DateTime date, int partySize);
    }
}
