using System;

namespace Locadora.Domain.Entidades
{
    public class Equipamento
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Cor { get; set; }
        public string Modelo { get; set; }
        public double SaldoEstoque { get; set; }
        public double ValorDiaria { get; set; }

        public Equipamento(string nome, string descricao, string cor, string modelo, double saldoEstoque, double valorDiaria)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Descricao = descricao;
            Cor = cor;
            Modelo = modelo;
            SaldoEstoque = saldoEstoque;
            ValorDiaria = valorDiaria;
        }
        public Equipamento(Guid id, string nome, string descricao, string cor, string modelo, double saldoEstoque, double valorDiaria)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Cor = cor;
            Modelo = modelo;
            SaldoEstoque = saldoEstoque;
            ValorDiaria = valorDiaria;
        }
    }
}
