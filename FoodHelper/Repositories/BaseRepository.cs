using FoodHelper.Data.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace FoodHelper.Data.Repositories
{
    public class BaseRepository<T> where T : BaseEntity, new()
    {
        protected FoodContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }

        public BaseRepository(FoodContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await DbSet.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Guid> AddAsync(T entity)
        {
            entity.Created = DateTime.Now;
            entity.Modified = DateTime.Now;
            await DbSet.AddAsync(entity);
            return entity.Id;
        }

        public async Task Update(T entity)
        {
            entity.Modified = DateTime.Now;

            var entry = await DbSet.FindAsync(entity.Id);

            if (entry != null)
            {
                DbContext.Entry(entry).CurrentValues.SetValues(entity);
            }
        }

        public async Task Delete(T entity)
        {
            var entry = await DbSet.FindAsync(entity.Id);

            if (entry != null)
            {
                DbSet.Remove(entity);
            }
        }
    }
}
