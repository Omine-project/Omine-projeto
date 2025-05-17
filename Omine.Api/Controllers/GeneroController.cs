using Microsoft.AspNetCore.Mvc;
using Omine.Domain.Entities;
using Omine.Domain.Service;

namespace Omine.Api.Controllers
{
    [Route("api/[controller]")]
    public class GeneroController : GenericControllerBase<Genero, Guid>
    {
        public GeneroController(Service<Genero, Guid> service) : base(service)
        {
        }
    }
}
