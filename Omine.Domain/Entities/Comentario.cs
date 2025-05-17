using Omine.Domain.Entities.Base;
using Omine.Domain.Entities;

public class Comentario : EntidadeBase<Guid>
{
    public string Texto { get; private set; }

    public Guid AnimeId { get; private set; }
    public Anime Anime { get; private set; }

    public Guid UsuarioId { get; private set; }
    public Usuario Usuario { get; private set; }

    public Comentario(string texto, Guid animeId, Guid usuarioId)
    {
        Texto = texto;
        AnimeId = animeId;
        UsuarioId = usuarioId;
    }

    public void AtualizarTexto(string novoTexto)
    {
        Texto = novoTexto;
        AtualizarDataAtualizacao(); 
    }
}
