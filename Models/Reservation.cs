using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant_API.Models
{
	public class Reservation
	{
		[Key]	
		public int ReservationNumber { get; set; }

		[Required]
		public int PartySize { get; set; }

		[Required]
		public DateTime DateTimeFrom { get; set; }

		[Required]
		public DateTime DateTimeTo { get; set; }

		[ForeignKey("Table")]
		public int TableNumberFK { get; set; }
		[Required]
		Table table {  get; set; }

		[ForeignKey("Customer")]
		public int CustomerIdFK { get; set; }
		[Required]
		Customer customer { get; set; }

		
	}
}
