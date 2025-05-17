using Omine.Domain.Entities;
using System.ComponentModel.DataAnnotations;

public class AnimeGenero
{
    [Key]
    public Guid AnimeId { get; set; }
    public Anime Anime { get; set; }

    [Key]
    public Guid GeneroId { get; set; }
    public Genero Genero { get; set; }

    public DateTime DataCriacao { get; private set; }
    public DateTime DataAtualizacao { get; private set; }

    protected AnimeGenero()
    {
        DataCriacao = DateTime.UtcNow;
        DataAtualizacao = DateTime.UtcNow;
    }

    public AnimeGenero(Guid animeId, Guid generoId)
    {
        AnimeId = animeId;
        GeneroId = generoId;
        DataCriacao = DateTime.UtcNow;
        DataAtualizacao = DateTime.UtcNow;
    }

    public void Atualizar(Guid animeId, Guid generoId)
    {
        AnimeId = animeId;
        GeneroId = generoId;
        DataAtualizacao = DateTime.UtcNow;
    }
}