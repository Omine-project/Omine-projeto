using Microsoft.AspNetCore.Mvc;
using Omine.Domain.Entities;

namespace Omine.Api.Controllers
{
    [Route("api/[controller]")]
    public class AnimeListaController : Controller
    {
        private readonly AnimeListaService _animeListaService;

        public AnimeListaController(AnimeListaService service)
        {
            _animeListaService = service;
        }
    }

}
