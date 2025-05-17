using Microsoft.AspNetCore.Components;
using Omine.Domain.Entities;
using Omine.Domain.Service;

namespace Omine.Api.Controllers
{
    [Route("api/[controller]")]
    public class AnimeController : GenericControllerBase<Anime, Guid>
    {
        public AnimeController(Service<Anime, Guid> service) : base(service)
        {
        }      
    }
}
