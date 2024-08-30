using System.ComponentModel.DataAnnotations;

namespace Restaurant_API.Models
{
	public class Dish	
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string DishName { get; set; }

		[Required]
		public int PriceInSek { get; set; }

		[Required]
        public bool IsAvailable { get; set; }
    }
}
