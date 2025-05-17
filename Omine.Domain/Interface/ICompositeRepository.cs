using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omine.Domain.Interface
{
    public interface ICompositeRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetByChavesCompostasAsync(params object[] chaves);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
