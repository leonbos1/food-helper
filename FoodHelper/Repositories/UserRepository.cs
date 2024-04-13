using FoodHelper.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FoodHelper.Repositories
{
    public class UserRepository
    {
        private FoodContext _dbContext;
        public UserRepository(FoodContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> GetFirstOrDefaultAsync(Expression<Func<User, bool>> predicate)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(predicate);
        }
    }
}