using System;

namespace Locadora.Domain.Entidades
{
    public class Equipamento : Entity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Cor { get; private set; }
        public string Modelo { get; private set; }
        public string Imagem { get; private set; }
        public double SaldoEstoque { get; private set; }
        public double ValorDiaria { get; private set; }
        public int QuantidadeAlugado { get; private set; }
        public Equipamento(Guid id, string nome, string descricao, string cor, string modelo, string imagem, double saldoEstoque, double valorDiaria, int quantidadeAlugado) : base(id)
        {
            Nome = nome;
            Descricao = descricao;
            Cor = cor;
            Modelo = modelo;
            Imagem = imagem;
            SaldoEstoque = saldoEstoque;
            ValorDiaria = valorDiaria;
            QuantidadeAlugado = quantidadeAlugado;
        }

        public Equipamento(string nome, string descricao, string cor, string modelo, string imagem, double saldoEstoque, double valorDiaria, int quantidadeAlugado)
        {
            Nome = nome;
            Descricao = descricao;
            Cor = cor;
            Modelo = modelo;
            Imagem = imagem;
            SaldoEstoque = saldoEstoque;
            ValorDiaria = valorDiaria;
            QuantidadeAlugado = quantidadeAlugado;
        }
    }
}
