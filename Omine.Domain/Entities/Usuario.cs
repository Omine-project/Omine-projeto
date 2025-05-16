using System;
using Omine.Domain.Entities.Base;

namespace Omine.Domain.Entities
{
    public class Usuario : EntidadeBase<Guid>
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        private string Senha { get; set; } 
        public DateTime DataNascimento { get; private set; }
        public string Telefone { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public bool Ativo { get; private set; }

        public Usuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            SetSenha(senha);
            DataCadastro = DateTime.UtcNow;
            Ativo = true;
        }

        protected Usuario() { }

        public void Atualizar(string nome, string email)
        {
            Nome = nome;
            Email = email;
            AtualizarDataAtualizacao();
        }

        public void AlterarSenha(string novaSenha)
        {
            SetSenha(novaSenha);
            AtualizarDataAtualizacao();
        }

        private void SetSenha(string senhaEmTextoPlano)
        {
            Senha = HashPassword(senhaEmTextoPlano);
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerificarSenha(string senhaEmTextoPlano)
        {
            return BCrypt.Net.BCrypt.Verify(senhaEmTextoPlano, Senha);
        }

        public void Desativar()
        {
            Ativo = false;
            AtualizarDataAtualizacao();
        }
    }
}