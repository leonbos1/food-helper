using FoodHelper.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodHelper.Data.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(FoodContext dbContext) : base(dbContext)
        {
        }

        public User? GetByEmail(string email)
        {
            return DbContext.Set<User>().FirstOrDefault(u => u.Email == email);
        }

        public User? GetByUsername(string username)
        {
            return DbContext.Set<User>().FirstOrDefault(u => u.Username == username);
        }
    }
}
