using FoodHelper.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodHelper.Data.Repositories
{
    public class FoodRepository : BaseRepository<Food>
    {
        public FoodRepository(FoodContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Food>> GetFiveLatestAddedFoodsAsync()
        {
            return await DbContext.Foods.OrderByDescending(f => f.Created).Take(5).ToListAsync();
        }

        public async Task<List<Food>> GetFiveProteinHighFoods()
        {
            return await DbContext.Foods.OrderByDescending(f => f.Proteins).Take(5).ToListAsync();
        }
    }
}