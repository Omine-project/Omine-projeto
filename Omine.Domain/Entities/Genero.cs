using Omine.Domain.Entities.Base;

namespace Omine.Domain.Entities
{
    public class Genero : EntidadeBase<Guid>
    {
        public string Nome { get; private set; }
        public string? Descricao { get; private set; }

        public Genero(string nome, string? descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        protected Genero() { }

        public void Atualizar(string nome, string? descricao)
        {
            Nome = nome;
            Descricao = descricao;
            AtualizarDataAtualizacao();
        }
    }
}