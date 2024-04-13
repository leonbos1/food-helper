using FoodHelper.Data.Models;
using FoodHelper.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodHelper.Repositories
{
    public class FoodRepository : BaseRepository<Food>
    {
        public FoodRepository(FoodContext dbContext) : base(dbContext)
        {
        }

        public async Task<Food?> GetByIdWithUserAsync(Guid id)
        {
            return await DbContext.Foods.Include(f => f.User).FirstOrDefaultAsync(f => f.Id == id);
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