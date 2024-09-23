namespace Restaurant_API.Models.DTOs
{
	public class CreateReservationDTO
	{
		public int ReservationNumber { get; set; }
		public int PartySize { get; set; }
		public int TableNr { get; set; }
		public int customerId { get; set; }
		public DateTime timeFrom { get; set; }
	}
}
