using System;

namespace Locadora.Domain.Queries
{
    public class ClienteQueryResult
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Role { get; set; }
    }
}