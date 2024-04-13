namespace FoodHelper.Repositories
{
    public interface IUnitOfWork
    {
        FoodRepository FoodRepository { get; }
        UserRepository UserRepository { get; }
        Task SaveChangesAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly FoodContext _context;
        public FoodRepository FoodRepository { get; private set; }
        public UserRepository UserRepository { get; private set; }

        public UnitOfWork(FoodContext context)
        {
            _context = context;
            FoodRepository = new FoodRepository(_context);
            UserRepository = new UserRepository(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
