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

		public async Task<ReservationResponseDTO> CreateReservation(CreateReservationDTO reservationDto)
		{
			var response = new ReservationResponseDTO();
			
			var customer = await _customerRepo.GetCustomerById(reservationDto.customerId);

			if(customer == null)
			{
				response.AddError("User not found");
				return response;
			}

			var tables = await _tableRepo.GetAllTables();

			//var availableTablesTimeSlot = tables.Where(t => t.Reservations.Any(r => r.DateTimeFrom < reservationDto.timeFrom && r.DateTimeTo > reservationDto.timeFrom.AddHours(2)));
			//if(availableTablesTimeSlot == null)
			//{
			//	response.AddError("No tables available during that timeslot");
			//	return response;
			//}

   //         var availableTablesPartySize = tables.Where(t => t.Seats >= reservationDto.PartySize);
   //         if (availableTablesPartySize == null)
			//{
			//	response.AddError("No table with your party size available");
			//	return response;
			//}

			var availableTable = tables
				.Where(t => t.Seats >= reservationDto.PartySize)
				.Where(t => !t.Reservations.Any(r => !(reservationDto.timeFrom >= r.DateTimeTo || reservationDto.timeFrom.AddHours(2) <= r.DateTimeFrom)))
				.FirstOrDefault();

			if (availableTable == null)
			{
				response.AddError("No tables available for that time with your party size!");
				return response;
			}

			// ***  Kan vara bra om man vill lägga till flera felmeddelanden ***

			//if (!response.SuccessfulReservation)
			//{
			//	return response;
			//}

			await _reservationRepo.CreateReservation(new Reservation
			{
				CustomerIdFK = reservationDto.customerId,
				TableNumberFK = availableTable.TableNumber,
				DateTimeFrom = reservationDto.timeFrom,
				DateTimeTo = reservationDto.timeFrom.AddHours(2),
				PartySize = reservationDto.PartySize
			});
			return response;
		}


		public async Task<GetReservationDTO> GetReservationById(int id)
		{
			var res = await _reservationRepo.GetReservationById(id);
			if (res == null)
			{
				return null;
			}
			return new GetReservationDTO
			{
				ReservationNumber = res.ReservationNumber,
				CustomerName = res.Customer.Name,
				PartySize = res.PartySize,
				phoneNr = res.Customer.Phone,
				TableNr = res.TableNumberFK,
				timeFrom = res.DateTimeFrom,
				timeTo = res.DateTimeTo,
			};
		}

		public async Task<IEnumerable<GetReservationDTO>> GetAllReservations()
		{
			var reservations = await _reservationRepo.GetAllReservations();
			if(reservations == null)
			{
				return null;
			}

			return reservations.Select(r => new GetReservationDTO
			{
				CustomerName = r.Customer.Name,
				phoneNr = r.Customer.Phone,
				ReservationNumber = r.ReservationNumber,
				PartySize = r.PartySize,
				TableNr = r.TableNumberFK,
				timeFrom = r.DateTimeFrom,
				timeTo = r.DateTimeTo,
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

		public async Task UpdateReservation(int reservationNumber, CreateReservationDTO updatedReservation)
		{
			var reservation = await _reservationRepo.GetReservationById(reservationNumber);
			reservation.TableNumberFK = updatedReservation.TableNr;
			reservation.CustomerIdFK = updatedReservation.customerId;
			reservation.PartySize = updatedReservation.PartySize;
			reservation.DateTimeFrom = updatedReservation.timeFrom;
			reservation.DateTimeTo = updatedReservation.timeFrom.AddHours(2);

			await _reservationRepo.UpdateReservation(reservation);
		}

		//Check if table available, if not return Choose another table!

		//Save customer and table to reservation

		//Save time and date for reserved table

		// Välja ett datum, hur många, sedan kan man se om det är ledigt, jämför med bokningar det tiden
	}
}
