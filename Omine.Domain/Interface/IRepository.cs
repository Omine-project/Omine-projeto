using Omine.Domain.Entities.Base;

namespace Omine.Infra.Interface
{
    public interface IRepository<TEntity, TId> where TEntity : EntidadeBase<TId>
    {
        Task<TEntity> GetByIdAsync(TId id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
