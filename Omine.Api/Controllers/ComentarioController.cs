using Microsoft.AspNetCore.Mvc;
using Omine.Domain.Service;

namespace Omine.Api.Controllers
{
    [Route("api/[controller]")]
    public class ComentarioController : GenericControllerBase<Comentario, Guid>
    {
        public ComentarioController(Service<Comentario, Guid> service) : base(service)
        {
        }
    }
}