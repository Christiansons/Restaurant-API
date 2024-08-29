using System.ComponentModel.DataAnnotations;

namespace Restaurant_API.Models
{
	public class Customer
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[StringLength(20)]
		public string Name { get; set; }
		[Required]
		[MinLength(10)]
		[MaxLength(14)]
		public string Phone { get; set; }

		public ICollection<Reservation>? Reservations { get; set; }
	}
}
