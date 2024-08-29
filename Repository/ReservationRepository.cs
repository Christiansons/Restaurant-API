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

        public async Task<Reservation> SaveReservation(Customer customer, Table table, DateTime from, DateTime to, int partySize)
		{
			Reservation reservation = new Reservation
			{
				CustomerIdFK = customer.Id,
				TableNumberFK = table.TableNumber,
				PartySize = partySize,
				DateTimeFrom = from,
				DateTimeTo = to
			};
			await _context.Reservations.AddAsync(reservation);
			await _context.SaveChangesAsync();
			return reservation;
		}
	}
}
