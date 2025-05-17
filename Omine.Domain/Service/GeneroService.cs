using Omine.Domain.Entities;
using Omine.Infra.Interface;

namespace Omine.Domain.Service
{
    public class GeneroService : Service<Genero, Guid>
    {
        public GeneroService(IRepository<Genero, Guid> repository) : base(repository)
        {
        }
    }
}
