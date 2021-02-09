using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Domain.Entidades
{
    public class Locacao : Entity
    {
        public Cliente Cliente { get; private set; }
        public List<Equipamento> Equipamentos { get; private set; }
        public DateTime DataLocacao { get; private set; }
        public DateTime DataDevolucao { get; private set; }
        public double ValorFrete { get; private set; }
        public double ValorAluguel { get; private set; }
        public double ValorTotal { get; private set; }

        public Locacao(Cliente cliente, List<Equipamento> equipamentos, DateTime dataLocacao, DateTime dataDevolucao, double valorFrete, double valorAluguel, double valorTotal)
        {
            Cliente = cliente;
            Equipamentos = equipamentos;
            DataLocacao = dataLocacao;
            DataDevolucao = dataDevolucao;
            ValorFrete = valorFrete;
            ValorAluguel = valorAluguel;
            ValorTotal = valorTotal;
            
            ClientePossuiEndereco();
            EquipamentoPossuiSaldoEstoque();
        }

        public bool ClientePossuiEndereco()
        {
            if (Cliente.Endereco == null)
            {
                AddNotification("Endereco", "O Cliente não possui endereço");
                return false;
            }

            return true;
        }

        public bool EquipamentoPossuiSaldoEstoque()
        {
            if (!Equipamentos.Any(e => e.SaldoEstoque > 0))
            {
                AddNotification("Equipamentos", "Alguns itens não possuem saldo em estoque");
                return false;
            }

            return true;
        }
    }
}
