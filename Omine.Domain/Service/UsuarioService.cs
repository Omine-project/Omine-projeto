using Omine.Domain.Entities;
using Omine.Infra.Interface;

namespace Omine.Domain.Service
{
    public class UsuarioService : Service<Usuario, Guid>
    {
        public UsuarioService(IRepository<Usuario, Guid> repository) : base(repository)
        {
        }
    }
}
