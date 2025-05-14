using System;
using Omine.Domain.Entities.Base;

namespace Omine.Domain.Entities
{
    public class Usuario : EntidadeBase<Guid>
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Telefone { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public bool Ativo { get; private set; } // Eu não coloquei isso no diagrama, mas vou deixar para decidir se vai ser utilizado ou não

        public Usuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            SetSenha(senha); // Usamos o método para garantir o hash
            Ativo = true;
        }

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
            // Implementação real de uma função de hash segura aqui
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerificarSenha(string senhaEmTextoPlano)
        {
            // Aqui você chamaria a função para verificar se a senha em texto plano corresponde ao hash
            return BCrypt.Net.BCrypt.Verify(senhaEmTextoPlano, Senha);
        }

        public void Desativar()
        {
            Ativo = false;
            AtualizarDataAtualizacao();
        }
    }
}