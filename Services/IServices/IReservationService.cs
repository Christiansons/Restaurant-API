using Restaurant_API.Models;
using Restaurant_API.Models.DTOs;
using Restaurant_API.Models.DTOs.CreateDTOs;

namespace Restaurant_API.Services.IServices
{
    public interface IReservationService
	{
		public Task<ReservationResponseDTO> CreateReservation(CreateReservationDTO dto);
		public Task<GetReservationDTO> GetReservationById(int id);
		public Task DeleteReservation(int id);
		public Task<IEnumerable<GetReservationDTO>> GetAllReservations();
		public Task UpdateReservation(int reservationNumber, UpdateReservationDTO updatedReservation);
	}
}
