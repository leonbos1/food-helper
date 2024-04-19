using FoodHelper.Data.Models.Base;

namespace FoodHelper.Models
{
    public class Meal : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public byte[]? Image { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<MealFood> MealFoods { get; set; }

        public Meal()
        {
            MealFoods = new List<MealFood>();
        }
    }
}
