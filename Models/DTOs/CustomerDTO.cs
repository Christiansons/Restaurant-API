namespace Restaurant_API.Models.DTOs
{
	public class CustomerDTO
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNr { get; set; }
        public IEnumerable<CreateReservationDTO>? reservationDTOs { get; set; }
    }
}
