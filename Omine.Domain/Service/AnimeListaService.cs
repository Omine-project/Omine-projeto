using Omine.Domain.Entities;
using Omine.Domain.Interface;

public class AnimeListaService
{
    private readonly ICompositeRepository<AnimeLista> _repository;

    public AnimeListaService(ICompositeRepository<AnimeLista> repository)
    {
        _repository = repository;
    }

    public async Task<AnimeLista?> GetByIdsAsync(Guid animeId, Guid listaId)
    {
        return await _repository.GetByChavesCompostasAsync(animeId, listaId);
    }

    public async Task AddAsync(AnimeLista entity)
    {
        await _repository.AddAsync(entity);
    }

    public async Task UpdateAsync(AnimeLista entity)
    {
        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(AnimeLista entity)
    {
        await _repository.DeleteAsync(entity);
    }
}
