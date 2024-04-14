using FoodHelper.Data.Models.Base;

namespace FoodHelper.Models
{
    public class MealFood : BaseEntity
    {
        public Guid MealId { get; set; }
        public Meal Meal { get; set; }
        public Guid FoodId { get; set; }
        public Food Food { get; set; }
    }
}
