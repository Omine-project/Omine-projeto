using Microsoft.AspNetCore.Mvc;
using Omine.Domain.Entities;
using Omine.Domain.Service;

namespace Omine.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : GenericControllerBase<Usuario, Guid>
    {
        public UsuarioController(Service<Usuario, Guid> service) : base(service)
        {
        }
    }
}
