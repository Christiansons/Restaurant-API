namespace Restaurant_API.Models.DTOs
{
	public class ReservationResponseDTO
	{
		public bool SuccessfulReservation = true;
		public List<string> Errors;
		public CreateReservationDTO reservationDto;

        public ReservationResponseDTO()
        {
            SuccessfulReservation = true;
			Errors = new List<string>();
        }

		public void AddError(string error)
		{
			SuccessfulReservation = false;
			Errors.Add(error);
		}
    }
}
