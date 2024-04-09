using FoodHelper.Data.Models;

namespace FoodHelper.Data.Repositories
{
    public class TokenRepository(FoodContext context) : BaseRepository<Token>(context)
    {
        private readonly FoodContext _context;

        public Token GetByValue(string value)
        {
            return _context.Tokens.FirstOrDefault(t => t.Value == value);
        }
    }
}
