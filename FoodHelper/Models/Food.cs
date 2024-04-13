using FoodHelper.Data.Models.Base;

namespace FoodHelper.Models
{
    public class Food : BaseEntity
    {
        public string? Name { get; set; }

        public double? Carbohydrates { get; set; }

        public double? Proteins { get; set; }

        public double? Fats { get; set; }

        public double? Fibres { get; set; }

        public double? Alcohol { get; set; }

        public double? Calories => (Carbohydrates * 4) + (Proteins * 4) + (Fats * 9) + (Alcohol * 7) + (Fibres * 2);

        public double? Weight { get; set; }

        public double? Price { get; set; }

        public string? Description { get; set; }

        public byte[]? Image { get; set; }

        public Guid? CategoryId { get; set; }

        public Category? Category { get; set; }

        public string? UserId { get; set; }

        public User? User { get; set; }
    }
}
