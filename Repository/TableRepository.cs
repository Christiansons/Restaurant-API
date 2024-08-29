using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Restaurant_API.Data;
using Restaurant_API.Repository.IRepository;

namespace Restaurant_API.Repository
{
	public class TableRepository : ITableRepository
	{
		RestaurantContext _context;
        public TableRepository(RestaurantContext context)
        {
            _context = context;
        }

		public Task<bool> CheckAvailabilty(DateTime timeFrom, int partySize)
		{
			return _context.Tables
				.Where(t=> t.Seats <= partySize)
				.Where(t => t.Reservations.Any(r => r.DateTimeFrom != ))
		}

		public async Task<IEnumerable<Table>> GetAllTables()
		{
			return await _context.Tables.ToListAsync();
		}

		public Task<Table> SaveTable(Table table)
		{
			throw new NotImplementedException();
		}
	}
}
