using Azure;
using Restaurant_API.Models;
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

		public async Task<ReservationResponseDTO> CreateReservation(ReservationDTO reservationDto)
		{
			var response = new ReservationResponseDTO();
			

			if (reservationDto.CustomerName.Length < 2)
			{
				response.AddError("Enter a longer name");
			}
			if (reservationDto.CustomerName.Length > 20)
			{
				response.AddError("Enter a shorter name");
			}
			if (reservationDto.PhoneNr.Length < 10 || reservationDto.PhoneNr.Length > 14)
			{
				response.AddError("Invalid phone number, please enter a valid one!");
			}

			var tables = await _tableRepo.GetAllTables();

			var availableTables = tables
				.Where(t => t.Seats >= reservationDto.PartySize)
				.Where(t => t.Reservations.Any(r => r.DateTimeFrom < reservationDto.timeFrom && r.DateTimeTo > reservationDto.timeFrom.AddHours(2)))
				.ToList();

			if (availableTables == null)
			{
				response.AddError("No tables available for that time with your party size!");
			}

			if (!response.SuccessfulReservation)
			{
				return response;
			}

			try
			{
				_reservationRepo.CreateReservation(new Reservation
				{
					CustomerIdFK = 
				});
			}
			

		}

		public async Task<ReservationDTO> GetReservationById(int id)
		{
			var res = await _reservationRepo.GetReservationById(id);
			if (res == null)
			{
				return null;
			}
			return new ReservationDTO
			{
				ReservationNumber = res.ReservationNumber,
				CustomerName = res.Customer.Name,
				PartySize = res.PartySize,
				PhoneNr = res.Customer.Phone,
				TableNr = res.TableNumberFK,
				timeFrom = res.DateTimeFrom,
				timeTo = res.DateTimeTo,
			};
		}

		public async Task<IEnumerable<ReservationDTO>> GetAllReservations()
		{
			var reservations = await _reservationRepo.GetAllReservations();
			if(reservations == null)
			{
				return null;
			}	

			return reservations.Select(r => new ReservationDTO
			{
				CustomerName = r.Customer.Name,
				PartySize = r.PartySize,
				PhoneNr = r.Customer.Phone,
				TableNr = r.TableNumberFK,
				ReservationNumber=r.ReservationNumber,
				timeFrom=r.DateTimeFrom,
				timeTo=r.DateTimeTo,
			}).ToList();
		}

		public async Task DeleteReservation(int id)
		{
			var reservation = await _reservationRepo.GetReservationById(id);
			if(reservation == null)
			{
				throw new NullReferenceException();
			}

			await _reservationRepo.DeleteReservation(reservation);
		}

		public async Task UpdateReservation(ReservationDTO reservation)
		{

		}

		//Check if table available, if not return Choose another table!

		//Save customer and table to reservation

		//Save time and date for reserved table

		// Välja ett datum, hur många, sedan kan man se om det är ledigt, jämför med bokningar det tiden
	}
}
