using Restaurant_API.Models;

namespace Restaurant_API.Repository.IRepository
{
	public interface IReservationRepository
	{
		public Task<int> CreateReservation(Reservation reservation);
		public Task DeleteReservation(Reservation reservation);
		public Task UpdateReservation(Reservation reservation);
		public Task<Reservation> GetReservationById(int id);
		public Task<IEnumerable<Reservation>> GetAllReservations();
	}
}
