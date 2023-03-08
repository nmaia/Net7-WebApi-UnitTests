using Hotel.Domain.Contracts.DomainServices;
using Hotel.Domain.Contracts.Repositories;

namespace Hotel.Domain.DomainServices
{
    public abstract class BaseDomainService<TEntity> : IBaseDomainService<TEntity>
        where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;

        protected BaseDomainService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual async Task<bool> RegisterAsync(TEntity obj)
        {
            return await _repository.InsertAsync(obj);
        }

        public virtual async Task<bool> UpdateAsync(TEntity obj)
        {
            return await _repository.UpdateAsync(obj);
        }

        public virtual async Task<bool> DeleteAsync(TEntity obj)
        {
            return await _repository.DeleteAsync(obj);
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual async Task<TEntity> GetByIDAsync(Guid id)
        {
            return await _repository.GetByIDAsync(id);
        }
    }
}
