using Omine.Infra.Interface;

namespace Omine.Domain.Service
{
    public class ComentarioService : Service<Comentario, Guid>
    {
        public ComentarioService(IRepository<Comentario, Guid> repository) : base(repository)
        {
        }
    }
}
