namespace Hotel.Domain.Contracts.DomainServices
{
    public interface IBaseDomainService<TEntity>
        where TEntity : class
    {
        Task<bool> RegisterAsync(TEntity obj);
        Task<bool> UpdateAsync(TEntity obj);
        Task<bool> DeleteAsync(TEntity obj);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIDAsync(Guid id);
    }
}
