using Microsoft.AspNetCore.Mvc;
using Omine.Domain.Service;

namespace Omine.Api.Controllers
{
    [Route("api/[controller]")]
    public class AnimeGeneroController 
    {
        private readonly AnimeGeneroService _animeGeneroService;

        public AnimeGeneroController(AnimeGeneroService service)
        {
            _animeGeneroService = service;
        }


    }
}
