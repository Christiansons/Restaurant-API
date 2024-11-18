namespace Restaurant_API.Models.DTOs.CreateDTOs
{
    public class CreateReservationDTO
    {
        public int PartySize { get; set; }
        public int customerId { get; set; }
        public DateTime timeFrom { get; set; }
    }
}
