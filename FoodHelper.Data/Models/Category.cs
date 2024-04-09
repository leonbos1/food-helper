namespace FoodHelper.Data.Models
{
    public class Category
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public List<Food>? Foods { get; set; }
    }
}