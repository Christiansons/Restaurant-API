using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Restaurant_API.Models.DTOs;
using Restaurant_API.Repository.IRepository;
using Restaurant_API.Services.IServices;

namespace Restaurant_API.Services
{
	public class ReservationService: IReservationService
	{
		private readonly IReservationRepository _reservationRepo;
		private readonly ITableRepository _tableRepo;
		private readonly ICustomerRepository _customerRepo;

        public ReservationService(IReservationRepository resRepo, ITableRepository tableRepo, ICustomerRepository custRepo)
        {
            _reservationRepo = resRepo;
			_tableRepo = tableRepo;
			_customerRepo = custRepo;
        }
		

		public Task OpenSlots() 
		{ 
			throw new NotImplementedException(); 
		}

		public async Task<ReservationResponseDTO> MakeReservation(ReservationDTO reservationDto)
		{
			var response = new ReservationResponseDTO();

			if(!await _tableRepo.CheckAvailabilty(reservationDto.timeFrom, reservationDto.PartySize))
			{
				response.AddError("No tables available for that time with your party size!");
			}

			if(reservationDto.CustomerName.Length < 2)
			{
				response.AddError("Enter a longer name");
			}

			if(reservationDto.CustomerName.Length > 20)
			{
				response.AddError("Enter a shorter name");
			}

			if (reservationDto.PhoneNr.Length < 10 || reservationDto.PhoneNr.Length > 14)
			{
				response.AddError("Invalid phone number, please enter a valid one!");
			}

			_reservationRepo.SaveReservation();

		}
		//Check if table available, if not return Choose another table!

		//Save customer and table to reservation

		//Save time and date for reserved table

		// Välja ett datum, hur många, sedan kan man se om det är ledigt, jämför med bokningar det tiden
	}
}
