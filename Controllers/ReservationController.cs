using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_API.Models;
using Restaurant_API.Models.DTOs;
using Restaurant_API.Models.DTOs.CreateDTOs;
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
		[Route("createRes")]
		//create reservation
		public async Task<IActionResult> CreateReservation([FromBody]CreateReservationDTO dto)
		{
			ReservationResponseDTO response = await _reservationService.CreateReservation(dto);
			if (!response.SuccessfulReservation)
			{
				return BadRequest(response.Errors); 
			}

			return Ok(response);
		}

		//Get resrevation by id
		[HttpGet]
		[Route("{reservationNumber}")]
		public async Task<ActionResult<CreateReservationDTO>> GetReservationById(int reservationNumber)
		{
			var reservation = await _reservationService.GetReservationById(reservationNumber);
			return Ok(reservation);
		}

		//Delete reservation
		[HttpDelete]
		[Route("delete/{reservationNumber}")]
		public async Task<IActionResult> DeleteReservation(int reservationNumber)
		{
			await _reservationService.DeleteReservation(reservationNumber);
			return Ok();
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<CreateReservationDTO>>> GetAllReservations()
		{
			var reservations = await _reservationService.GetAllReservations();
			return Ok(reservations);
		}

		[HttpPatch]
		[Route("update/{reservationNumber}")]
		public async Task<IActionResult> UpdateReservation(int reservationNumber, [FromBody]CreateReservationDTO updatedReservation)
		{
			await _reservationService.UpdateReservation(reservationNumber, updatedReservation);
			return Ok("Updated");
		}
	}
}
