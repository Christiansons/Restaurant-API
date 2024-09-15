namespace Restaurant_API.Models.DTOs
{
	public class CreateReservationDTO
	{
		public int PartySize { get; set; }
		public string CustomerName { get; set; }
		public string PhoneNr { get; set; }
		public int TableNr { get; set; }
		public DateTime timeFrom { get; set; } //Tänker att man får sitta i 2h så behöver inte ta emot sluttiden,
		public DateTime timeTo { get; set; }
	}
}
