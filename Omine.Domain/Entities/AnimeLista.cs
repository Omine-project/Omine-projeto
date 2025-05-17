using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omine.Domain.Entities
{
    public class AnimeLista
    {
        [Key]
        public Guid AnimeId { get; set; }
        public Anime Anime { get; set; }

        [Key]
        public Guid ListaId { get; set; }
        public Lista Lista { get; set; }

        public DateTime? DateCriacao { get; private set; }
        public DateTime? DateAtualizacao { get; private set; }

        public AnimeLista()
        {
            DateCriacao = DateTime.UtcNow;
            DateAtualizacao = DateTime.UtcNow;
        }

        public AnimeLista(Guid animeId, Guid listaId, DateTime? dataCriacao, DateTime? ultimaAlteracao)
        {
            AnimeId = animeId;
            ListaId = listaId;
            DateCriacao = dataCriacao;
            DateAtualizacao = ultimaAlteracao;
        }
    }
}
