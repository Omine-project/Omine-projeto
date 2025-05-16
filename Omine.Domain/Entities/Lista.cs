using System;
using System.ComponentModel.DataAnnotations.Schema;
using Omine.Domain.Entities.Base;
using Omine.Domain.Enum;

namespace Omine.Domain.Entities
{
    public class Lista : EntidadeBase<Guid>
    {
        [ForeignKey("Usuario")]
        public virtual Guid IdUsuario { get; private set; }
        public virtual Usuario Usuario { get; private set; }

        public virtual string Nome { get; private set; }
        public virtual string Descricao { get; private set; }
        public virtual DateTime DataCriacao { get; private set; }
        public virtual NivelAcessoEnum NivelAcesso { get; private set; }
        public virtual float Avaliacao { get; private set; }
        public virtual StatusEnum Status { get; private set; }

        public Lista(Guid idUsuario, string nome, string descricao, NivelAcessoEnum nivelAcesso, StatusEnum status)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Descricao = descricao;
            DataCriacao = DateTime.UtcNow;
            NivelAcesso = nivelAcesso;
            Avaliacao = 0.0f; 
            Status = StatusEnum.Ativo; 
        }

        protected Lista() { }

        public void Atualizar(string nome, string descricao, NivelAcessoEnum nivelAcesso)
        {
            Nome = nome;
            Descricao = descricao;
            NivelAcesso = nivelAcesso;
            AtualizarDataAtualizacao();
        }

        public void AtualizarAvaliacao(float avaliacao)
        {
            Avaliacao = avaliacao;
            AtualizarDataAtualizacao();
        }

        public void AlterarStatus(StatusEnum status)
        {
            Status = status;
            AtualizarDataAtualizacao();
        }
    }
}