using Microsoft.EntityFrameworkCore;

namespace FoodHelper.Data.Repositories
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        protected DbContext DbContext { get; set; }

        public BaseRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>().ToList();
        }

        public virtual TEntity? GetById(int id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public async virtual Task Add(TEntity entity)
        {
            await DbContext.Set<TEntity>().AddAsync(entity);
        }

        public virtual void Update(TEntity entity)
        {
            DbContext.Set<TEntity>().Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
        }

        public virtual void Save()
        {
            DbContext.SaveChangesAsync();
        }

        public virtual void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
