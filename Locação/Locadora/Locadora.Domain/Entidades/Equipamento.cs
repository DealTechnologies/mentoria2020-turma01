using System;

namespace Locadora.Domain.Entidades
{
    public class Equipamento : Entity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Cor { get; private set; }
        public string Modelo { get; private set; }
        public double SaldoEstoque { get; private set; }
        public double ValorDiaria { get; private set; }
        public Equipamento(Guid id, string nome, string descricao, string cor, string modelo, double saldoEstoque, double valorDiaria) : base(id)
        {
            Nome = nome;
            Descricao = descricao;
            Cor = cor;
            Modelo = modelo;
            SaldoEstoque = saldoEstoque;
            ValorDiaria = valorDiaria;
        }
    }
}
