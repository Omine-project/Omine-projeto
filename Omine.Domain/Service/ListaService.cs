using Omine.Domain.Entities;
using Omine.Infra.Interface;

namespace Omine.Domain.Service
{
    public class ListaService : Service<Lista, Guid>
    {
        public ListaService(IRepository<Lista, Guid> repository) : base(repository)
        {
        }
    }
}
