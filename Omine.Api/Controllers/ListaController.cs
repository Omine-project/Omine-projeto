using Microsoft.AspNetCore.Mvc;
using Omine.Domain.Entities;
using Omine.Domain.Service;

namespace Omine.Api.Controllers
{
    [Route("api/[controller]")]
    public class ListaController : GenericControllerBase<Lista, Guid>
    {
        public ListaController(Service<Lista, Guid> service) : base(service)
        {
        }
    }
}