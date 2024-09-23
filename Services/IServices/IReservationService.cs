using Restaurant_API.Models.DTOs;

namespace Restaurant_API.Services.IServices
{
	public interface IReservationService
	{
		public Task<bool> CheckAvailabilty();
		public Task<ReservationResponseDTO> CreateReservation(CreateReservationDTO dto);
		public Task<CreateReservationDTO> GetReservationById(int id);
		public Task DeleteReservation(int id);
		public Task<IEnumerable<CreateReservationDTO>> GetAllReservations();
	}
}
