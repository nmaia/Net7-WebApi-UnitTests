using Hotel.Domain.Contracts.Repositories;
using Hotel.Infra.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infra.Repository.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly HotelContextDb _dbContext;

        protected BaseRepository(HotelContextDb dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteAsync(TEntity obj)
        {
            _dbContext.Entry(obj).State = EntityState.Deleted;
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIDAsync(Guid id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<bool> InsertAsync(TEntity obj)
        {
            _dbContext.Entry(obj).State = EntityState.Added;
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(TEntity obj)
        {
            _dbContext.Entry(obj).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
