using Locadora.Domain.ValueObjects;
using System;

namespace Locadora.Domain.Entidades
{
    public class Cliente : Entity
    {
        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public string Rg { get; private set; }
        public Cpf Cpf { get; private set; }
        public Email Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Role { get; private set; }
        public Endereco Endereco { get; private set; }

        public Cliente(string nome, string senha, string rg, string cpf, string email, DateTime dataNascimento, string role = "Cliente")
        {
            Nome = nome;
            Senha = senha;
            Rg = rg;
            DataNascimento = dataNascimento;
            Role = role;

            AtribuirCpf(cpf);
            AtribuirEmail(email);

            EhValido();
        }

        public Cliente(Guid id, string nome, string senha, string rg, string cpf, string email, DateTime dataNascimento, string role = "Cliente")
            : base(id)
        {
            Nome = nome;
            Senha = senha;
            Rg = rg;
            DataNascimento = dataNascimento;
            Role = role;

            AtribuirCpf(cpf);
            AtribuirEmail(email);

            EhValido();
        }

        public bool EhValido()
        {
            if (Invalid)
                return false;

            return true;
        }

        private void AtribuirCpf(string numeroCpf)
        {
            var cpf = new Cpf(numeroCpf);
            if (!Cpf.EhValido())
            {
                AddNotification("Cpf","Cpf inválido.");
                return;
            }

            Cpf = cpf;
        }

        private void AtribuirEmail(string enderecoEmail)
        {
            var email = new Email(enderecoEmail);
            if (!email.EhValido())
            {
                AddNotification("Email", "E-mail inválido.");
                return;
            }

            Email = email;
        }

        public void AtribuirEndereco(string cep, string rua, int numero, string complemento, string cidade, string estado, string pais, bool principal = true)
        {
            var endereco = new Endereco(cep, rua, numero, complemento, cidade, estado, pais, principal);
            if (!endereco.EhValido())
            {
                AddNotification("Endereco", "Endereco inválido.");
                return;
            }

            Endereco = endereco;
        }
    }
}