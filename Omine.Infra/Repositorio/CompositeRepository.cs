using Microsoft.EntityFrameworkCore;
using Omine.Domain.Interface;

namespace Omine.Infra.Repositorio
{
    public class CompositeRepository<TEntity> : ICompositeRepository<TEntity> where TEntity : class
    {
        protected readonly OmineContext _context;

        public CompositeRepository(OmineContext context)
        {
            _context = context;
        }

        public async Task<TEntity?> GetByChavesCompostasAsync(params object[] chaves)
        {
            // Exemplo usando chave composta (para um relacionamento com duas chaves, como AnimeId e ListaId)
            return await _context.Set<TEntity>().FindAsync(chaves);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

    }
}