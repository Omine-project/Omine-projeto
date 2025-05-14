using System.ComponentModel.DataAnnotations;

namespace Omine.Domain.Entities.Base
{
    public abstract class EntidadeBase<TId>
    {
        [Key]
        public virtual TId Id { get; protected set; }
        public virtual DateTime CriadoEm { get; private set; }
        public virtual DateTime AtualizadoEm { get; private set; }

        protected EntidadeBase()
        {
            CriadoEm = DateTime.UtcNow;
            AtualizadoEm = DateTime.UtcNow;
        }

        public void AtualizarDataAtualizacao()
        {
            AtualizadoEm = DateTime.UtcNow;
        }
    }
}