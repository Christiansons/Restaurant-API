namespace Restaurant_API.Models.DTOs
{
	public class CustomerDTO
	{
        public string Name { get; set; }
        public string PhoneNr { get; set; }
        public IEnumerable<ReservationDTO>? reservationDTOs { get; set; }
    }
}
