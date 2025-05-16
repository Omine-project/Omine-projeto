using System;
using System.ComponentModel.DataAnnotations.Schema;
using Omine.Domain.Entities.Base;

namespace Omine.Domain.Entities
{
    public class Comentario : EntidadeBase<Guid>
    {
        [ForeignKey("Anime")]
        public Guid IdAnime { get; private set; }
        public virtual Anime Anime { get; private set; } // virtual para permitir o lazy loading

        [ForeignKey("Lista")]
        public Guid IdLista { get; private set; }
        public virtual Lista Lista { get; private set; }

        public string Texto { get; private set; }
        public DateTime DataAvaliacao { get; private set; }
        public int Curtidas { get; private set; }

        public Comentario(Guid idAnime, Guid idLista, string texto)
        {
            IdAnime = idAnime;
            IdLista = idLista;
            Texto = texto;
            DataAvaliacao = DateTime.UtcNow;
            Curtidas = 0;
        }

        protected Comentario() { }

        public void AdicionarCurtida()
        {
            Curtidas++;
        }

        public void Descurtir()
        {
            if (Curtidas > 0)
            {
                Curtidas--;
                AtualizarDataAtualizacao(); 
            }
        }

        public void AtualizarTexto(string texto)
        {
            Texto = texto;
            AtualizarDataAtualizacao();
        }
        public Comentario BuscarComentario(Guid idComentario)
        {
            if (Id == idComentario)
            {
                return this;
            }
            return null;
        }
    }
}