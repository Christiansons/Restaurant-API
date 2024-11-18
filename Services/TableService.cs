using Restaurant_API.Models;
using Restaurant_API.Models.DTOs;
using Restaurant_API.Models.DTOs.CreateDTOs;
using Restaurant_API.Repository.IRepository;
using Restaurant_API.Services.IServices;

namespace Restaurant_API.Services
{
	public class TableService : ITableService
	{
		//Inject repository
		private readonly ITableRepository _tableRepo;
        public TableService(ITableRepository tableRepository)
        {
            _tableRepo = tableRepository;
        }


        public async Task CreateTable(CreateTableDTO dto)
		{
            if(dto == null)
			{
				return;
			}

			await _tableRepo.CreateTable(new Table
			{
				Seats = dto.Seats,
				TableNumber = dto.TableNr,
			});
        }

		public async Task DeleteTable(int id)
		{
			if(id < 0)
			{
				throw new Exception();
			}

			Table table = await _tableRepo.GetTableById(id);

			if(table == null)
			{
				throw new NullReferenceException();
			}

			await _tableRepo.DeleteTable(table);
		}

		public async Task<IEnumerable<TableDTO>> GetAllTables()
		{
			var tables = await _tableRepo.GetAllTables();

			return tables.Select(t=> new TableDTO
			{
				tableId = t.TableId,
				Seats=t.Seats,
				TableNr = t.TableNumber
			}).ToList();
		}

		//Gets available tables for specific date
        public async Task<IEnumerable<AvailableTimeForDateDTO>> GetAvialableTablesForDate(DateTime date, int partySize)
        {
            List<(TimeSpan timeFrom, TimeSpan timeTo)> TimeSlots = new() //Lägga i global-fil?
			{
				(new TimeSpan(16, 0, 0), new TimeSpan(18, 0, 0) ),
				(new TimeSpan(18, 0, 0), new TimeSpan(20, 0, 0) ),
				(new TimeSpan(20, 0, 0), new TimeSpan(22, 0, 0) ),
				(new TimeSpan(22, 0, 0), new TimeSpan(24, 0, 0) )
			};

            var allTables = await _tableRepo.GetAllTables();
			
			var availableSlots = new List<AvailableTimeForDateDTO>();

			foreach(var slot in TimeSlots)
			{

				//Create slots for the actual date

				var slotTime = new List<(DateTime timeFrom, DateTime timeTo)>
				{
					(date.Date.Add(slot.timeFrom),date.Date.Add(slot.timeTo))
				};

				var timeFrom = date.Date.Add(slot.timeFrom);
                var timeTo = date.Date.Add(slot.timeTo);

				bool isSlotAvailable = allTables.Any(t =>
					t.Seats >= partySize &&
					t.Reservations.All(tr =>
						tr.DateTimeTo <= timeFrom || tr.DateTimeFrom >= timeTo));

				availableSlots.Add(new()
				{
					IsAvailable = isSlotAvailable,
					SlotStart = timeFrom,
					SlotEnd = timeTo,
				});
            }

			return availableSlots;
        }

		//

        public async Task<TableDTO> GetTableByTableNr(int id)
		{
			try
			{
				var table = await _tableRepo.GetTableById(id);
				return new TableDTO
				{
					Seats = table.Seats,
					TableNr = table.TableNumber
				};
			}
			catch (Exception)
			{
				return null;
			}
		}

		//Kolla med aldor bool?
		public async Task<bool> UpdateTable(int tableId, TableDTO dto)
		{
			try
			{
				var table = await _tableRepo.GetTableById(tableId);
				table.Seats = dto.Seats;
				table.TableNumber = dto.TableNr;
				await _tableRepo.UpdateTable(table);
				return true;
			} catch (Exception)
			{
				return false;
			}
		}
	}
}
