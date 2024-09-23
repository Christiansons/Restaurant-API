namespace Restaurant_API.Models.DTOs
{
	public class GetReservationDTO
	{
		public int ReservationNumber { get; set; }
		public int PartySize { get; set; }
		public int TableNr { get; set; }
		public string CustomerName { get; set; }
		public string phoneNr { get; set; }
		public DateTime timeFrom { get; set; }
		public DateTime timeTo { get; set; }
	}
}
