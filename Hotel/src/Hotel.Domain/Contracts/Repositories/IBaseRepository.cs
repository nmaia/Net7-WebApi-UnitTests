﻿namespace Hotel.Domain.Contracts.Repositories
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        Task<bool> InsertAsync(TEntity obj);
        Task<bool> UpdateAsync(TEntity obj);
        Task<bool> DeleteAsync(TEntity obj);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIDAsync(Guid id);
    }
}
