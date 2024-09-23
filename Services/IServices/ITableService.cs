using Restaurant_API.Models.DTOs;

namespace Restaurant_API.Services.IServices
{
	public interface ITableService
	{
		public Task CreateTable(int seats);
		public Task<bool> UpdateTable(int id, int seats);
		public Task DeleteTable(int id);
		public Task<TableDTO> GetTableByTableNr(int id);
		public Task<IEnumerable<TableDTO>> GetAllTables();
	}
}
