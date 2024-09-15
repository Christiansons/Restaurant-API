using Restaurant_API.Models.DTOs;

namespace Restaurant_API.Services.IServices
{
	public interface IReservationService
	{
		public Task<bool> CheckAvailabilty();
		public Task<ReservationResponseDTO> CreateReservation(ReservationDTO dto);
		public Task<ReservationDTO> GetReservationById(int id);
		public Task DeleteReservation(int id);
	}
}
