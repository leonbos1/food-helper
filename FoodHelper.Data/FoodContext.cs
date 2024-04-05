using FoodHelper.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodHelper.Data
{
    public class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions<FoodContext> options) : base(options)
        {
        }

        public DbSet<Food> Foods { get; set; }
    }
}
