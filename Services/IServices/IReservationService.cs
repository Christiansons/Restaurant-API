using Restaurant_API.Models.DTOs;

namespace Restaurant_API.Services.IServices
{
	public interface IReservationService
	{
		public Task<bool> CheckAvailabilty();
		public Task<ReservationResponseDTO> MakeReservation(ReservationDTO dto);
	}
}
