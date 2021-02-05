using System;
using System.Collections.Generic;
using System.Text;

namespace Locadora.Domain.Queries
{
    public class EquipamentoQueryResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Cor { get; set; }
        public string Modelo { get; set; }
        public double SaldoEstoque { get; set; }
        public double ValorDiaria { get; set; }


    }
}
