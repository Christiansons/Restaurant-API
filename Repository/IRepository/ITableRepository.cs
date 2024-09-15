using Restaurant_API.Models;

namespace Restaurant_API.Repository.IRepository
{
	public interface ITableRepository
	{
		public Task UpdateTable(Table table);
		public Task CreateTable(Table table);
		public Task DeleteTable(Table table);
		public Task<IEnumerable<Table>> GetAllTables();
		public Task<Table> GetTableById(int id);
	}
}
