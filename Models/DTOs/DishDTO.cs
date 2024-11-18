namespace Restaurant_API.Models.DTOs
{
	public class DishDTO
	{
        public int? Id {  get; set; }
        public string DishName { get; set; }
        public int PriceInSek { get; set; }
        public bool IsAvailable { get; set; }
    }
}
