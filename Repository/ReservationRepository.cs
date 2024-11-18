using Microsoft.EntityFrameworkCore;
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

        public async Task<int> CreateReservation(Reservation reservation)
		{
			await _context.Reservations.AddAsync(reservation);
			await _context.SaveChangesAsync();
			return reservation.ReservationNumber;
		}

		public async Task DeleteReservation(Reservation reservation)
		{
			if(reservation != null)
			{
				_context.Reservations.Remove(reservation);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<Reservation>> GetAllReservations()
		{
			return await _context.Reservations.Include(r => r.Customer).ToListAsync();
		}

		public async Task<Reservation> GetReservationById(int id)
		{
			return await _context.Reservations.Where(r => r.ReservationNumber == id).Include(r => r.Customer).Include(r=> r.Table).FirstOrDefaultAsync();
		}

		public async Task UpdateReservation(Reservation reservation)
		{
			_context.Reservations.Update(reservation);
			await _context.SaveChangesAsync();
		}
	}
}
