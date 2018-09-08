using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MD.Data
{
    /// <summary>
    /// Generic repository class.
    /// </summary>
    /// <typeparam name="TEntity">Class that extends <see cref="Entity"/> class.</typeparam>
    public class Repository<TEntity> : IDisposable
        where TEntity : Entity
    {
        private readonly DbContext _dbContext;
        private bool _disposed;

        protected IDbSet<TEntity> DbSet => _dbContext.Set<TEntity>();

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get all entities.
        /// </summary>
        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        /// <summary>
        /// Create entity in database.
        /// </summary>
        /// <param name="item">item to be created.</param>
        public void Create(TEntity item)
        {
            DbSet.Add(item);
        }

        /// <summary>
        /// Create items in database.
        /// </summary>
        /// <param name="items">collection of items to be created.</param>
        public void Create(IEnumerable<TEntity> items)
        {
            foreach (var entity in items)
            {
                DbSet.Add(entity);
            }
        }

        /// <summary>
        /// Get entity by id in async manner.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <returns></returns>
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Update entity state.
        /// </summary>
        /// <param name="item">Entity to be updated.</param>
        public void Update(TEntity item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        /// <summary>
        /// Delete entity in database by id in async manner.
        /// </summary>
        /// <param name="id">id of the entity to be deleted.</param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            var item = await DbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (item != null)
            {
                DbSet.Remove(item);
            }
        }

        /// <summary>
        /// Save changes in async manner.
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}