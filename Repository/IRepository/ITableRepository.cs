using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Restaurant_API.Repository.IRepository
{
	public interface ITableRepository
	{
		public Task<Table> SaveTable(Table table);
		public Task<IEnumerable<Table>> GetAllTables();
		public Task<bool> CheckAvailabilty(DateTime timeFrom, int partySize);
	}
}
