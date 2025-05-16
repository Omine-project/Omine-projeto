using System;
using System.ComponentModel.DataAnnotations.Schema;
using Omine.Domain.Entities.Base;

namespace Omine.Domain.Entities
{
    public class Anime : EntidadeBase<Guid>
    {
        public virtual string Nome { get; private set; }
        public virtual string? Descricao { get; private set; }

        [ForeignKey("Genero")]
        public virtual Guid IdGenero { get; private set; }
        public virtual Genero Genero { get; private set; }

        public virtual DateTime DataLancamento { get; private set; }
        public virtual string? Estudio { get; private set; }
        public virtual string? UrlImagem { get; private set; }
        public virtual float Avaliacao { get; private set; }
        public virtual int TotalEpisodios { get; private set; }
        public virtual int ClassificacaoIndicativa { get; private set; }
        public virtual int ClassificacaoRanking { get; private set; }

        public Anime(string nome, string? descricao, Guid idGenero, DateTime dataLancamento, string? estudio, string? urlImagem, float avaliacao, int totalEpisodios, int classificacaoIndicativa, int classificacaoRanking)
        {
            Nome = nome;
            Descricao = descricao;
            IdGenero = idGenero;
            DataLancamento = dataLancamento;
            Estudio = estudio;
            UrlImagem = urlImagem;
            Avaliacao = avaliacao;
            TotalEpisodios = totalEpisodios;
            ClassificacaoIndicativa = classificacaoIndicativa;
            ClassificacaoRanking = classificacaoRanking;
        }

        protected Anime() { }

        public void Atualizar(string nome, string? descricao, Guid idGenero, DateTime dataLancamento, string? estudio, string? urlImagem, float avaliacao, int totalEpisodios, int classificacaoIndicativa, int classificacaoRanking)
        {
            Nome = nome;
            Descricao = descricao;
            IdGenero = idGenero;
            DataLancamento = dataLancamento;
            Estudio = estudio;
            UrlImagem = urlImagem;
            Avaliacao = avaliacao;
            TotalEpisodios = totalEpisodios;
            ClassificacaoIndicativa = classificacaoIndicativa;
            ClassificacaoRanking = classificacaoRanking;
            AtualizarDataAtualizacao();
        }

        public void AtualizarAvaliacao(float avaliacao)
        {
            Avaliacao = avaliacao;
            AtualizarDataAtualizacao();
        }

        public void AtualizarTotalEpisodios(int totalEpisodios)
        {
            TotalEpisodios = totalEpisodios;
            AtualizarDataAtualizacao();
        }

        public void AtualizarClassificacaoRanking(int classificacaoRanking)
        {
            ClassificacaoRanking = classificacaoRanking;
            AtualizarDataAtualizacao();
        }

        public void AtualizarUrlImagem(string urlImagem)
        {
            UrlImagem = urlImagem;
            AtualizarDataAtualizacao();
        }

        public void AtualizarDescricao(string? descricao)
        {
            Descricao = descricao;
            AtualizarDataAtualizacao();
        }
    }
}