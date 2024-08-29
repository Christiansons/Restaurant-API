using Restaurant_API.Models;

namespace Restaurant_API.Repository.IRepository
{
	public interface IReservationRepository
	{
		public Task<Reservation> SaveReservation(Customer customer, Table table, DateTime from, DateTime to, int partySize);
	}
}
