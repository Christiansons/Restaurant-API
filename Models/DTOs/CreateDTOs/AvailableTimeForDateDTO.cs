namespace Restaurant_API.Models.DTOs.CreateDTOs
{
    public class AvailableTimeForDateDTO
    {
        public DateTime SlotStart {  get; set; }
        public DateTime SlotEnd { get; set; }
        public bool IsAvailable { get; set; }
    }
}
