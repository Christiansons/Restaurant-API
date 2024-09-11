using Restaurant_API.Models;

namespace Restaurant_API.Repository.IRepository
{
	public interface ITableRepository
	{
		public Task UpdateTable(Table table);
		public Task<Table> SaveTable(Table table);
		public Task RemoveTable(Table table);
		public Task<IEnumerable<Table>> GetAllTables();
		public Task<Table> GetTableById(int id);
		public Task<IEnumerable<Table>> CheckAvailabiltyAndReturnAvailableTables(DateTime timeFrom, int partySize);
	}
}
