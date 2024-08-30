using Restaurant_API.Data;
using Restaurant_API.Models;
using Restaurant_API.Repository.IRepository;

namespace Restaurant_API.Repository
{
	public class ReservationRepository : IReservationRepository
	{
		private readonly RestaurantContext _context;
        public ReservationRepository(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<Reservation> SaveReservation(Reservation reservation)
		{
			await _context.Reservations.AddAsync(reservation);
			await _context.SaveChangesAsync();
			return reservation;
		}

		public async Task<Table> CreateTable(Table table)
		{
			await _context.Tables.AddAsync(table);
			await _context.SaveChangesAsync();
			return table;
		}

		public async Task DeleteTable(Table table)
		{
			Table tableToRemove = await _context.Tables.FindAsync(table);

			if (tableToRemove != null)
			{
				_context.Tables.Remove(tableToRemove);
				await _context.SaveChangesAsync();
			}
		}

		public async Task UpdateTable(Table table)
		{
			_context.Tables.Update(table);
			await _context.SaveChangesAsync();
		}
	}
}
