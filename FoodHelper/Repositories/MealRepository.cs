using FoodHelper.Models;

namespace FoodHelper.Repositories
{
    public class MealRepository : BaseRepository<Meal>
    {
        public MealRepository(FoodContext context) : base(context)
        {
        }
    }
}
