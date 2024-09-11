using Restaurant_API.Models;

namespace Restaurant_API.Repository.IRepository
{
	public interface IReservationRepository
	{
		public Task<Reservation> SaveReservation(Reservation reservation);
		public Task<Table> CreateTable(Table table);
		public Task DeleteTable(Table table);
		public Task UpdateTable(Table table);
	}
}
