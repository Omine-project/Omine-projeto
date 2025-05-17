using Omine.Domain.Entities.Base;
using Omine.Infra.Interface;

namespace Omine.Domain.Service
{
    public class Service<TEntity, TId> where TEntity : EntidadeBase<TId>
    {
        protected readonly IRepository<TEntity, TId> _repository;

        public Service(IRepository<TEntity, TId> repository)
        {
            _repository = repository;
        }

        public async Task<TEntity> GetByIdAsync(TId id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(TId id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                await _repository.DeleteAsync(entity);
            }
        }
    }
}
