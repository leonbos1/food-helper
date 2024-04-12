using FoodHelper.Data.Models;

namespace FoodHelper.Data.Repositories
{
    public class FoodRepository : BaseRepository<Food>
    {
        public FoodRepository(FoodContext dbContext) : base(dbContext)
        {
        }
    }
}