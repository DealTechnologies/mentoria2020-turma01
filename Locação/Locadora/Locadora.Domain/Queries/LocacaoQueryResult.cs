using Locadora.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace Locadora.Domain.Queries
{
    public class LocacaoQueryResult
    {
        public ClienteQueryResult Cliente { get; set; }
        public List<EquipamentoQueryResult> Equipamentos { get; set; }

        public string DataLocacao { get; set; }
        public string DataDevolucao { get; set; }
        public double ValorFrete { get; set; }
        public double ValorAluguel { get; set; }
        public double ValorTotal { get; set; }
    }
}
