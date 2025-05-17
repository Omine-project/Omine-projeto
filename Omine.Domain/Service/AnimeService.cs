using Omine.Domain.Entities;
using Omine.Infra.Interface;

namespace Omine.Domain.Service
{
    public class AnimeService : Service<Anime, Guid>
    {
        public AnimeService(IRepository<Anime, Guid> repository) : base(repository)
        {
        }
    }
}