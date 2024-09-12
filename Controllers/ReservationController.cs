using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_API.Models;
using Restaurant_API.Models.DTOs;
using Restaurant_API.Services.IServices;

namespace Restaurant_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReservationController : ControllerBase
	{
		private readonly IReservationService _reservationService;
        public ReservationController(IReservationService resService)
        {
            _reservationService = resService;
        }

        [HttpPost]
		[Route("reservation")]
		//Skickar och tar emot DTO för att kunna visa upp bokningen när den är gjord
		public async Task<IActionResult> Reservation(ReservationDTO dto)
		{
			ReservationResponseDTO response = await _reservationService.MakeReservation(dto);
			if (!response.SuccessfulReservation)
			{
				return BadRequest(response.Errors); 
			}

			return Ok(response);
		}
	}
}
