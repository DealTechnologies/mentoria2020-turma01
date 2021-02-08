using Flunt.Notifications;
using Locadora.Domain.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Locadora.Domain.Commands.Locacoes.Inputs
{
    public class AdicionarLocacaoCommand : Notifiable, ICommandPadrao
    {
        public Guid IdUsuario { get; set; }
        public List<EquipamentoDto> Equipamentos { get; set; }
        public string DataLocacao { get; set; }
        public string DataDevolucao { get; set; }
        public double ValorFrete { get; set; }
        public double ValorAluguel { get; set; }
        public double ValorTotal { get; set; }
        public DateTime DataLocacaoConvertida { get; private set; }
        public DateTime DataDevolucaoConvertida { get; private set; }

        public bool ValidarCommand()
        {
            try
            {
                if (Guid.Empty == IdUsuario)
                    AddNotification("Id", "IdUsuario obrigatório");

                if (Equipamentos == null)
                    AddNotification("Equipamentos", "Lista de Equipamentos obrigatório");
                else if (Equipamentos.Count() <= 0)
                    AddNotification("Equipamentos", "Lista de Equipamentos obrigatório");

                if (ValorFrete <= 0.0)
                    AddNotification("ValorFrete", "Valor do Frete obrigatório");
                
                if (ValorAluguel <= 0.0)
                    AddNotification("ValorAluguel", "Valor do Aluguel obrigatório");
                
                if (ValorTotal <= 0.0)
                    AddNotification("ValorTotal", "Valor Total obrigatório");
                else if (ValorTotal < (ValorFrete + ValorAluguel))
                    AddNotification("ValorTotal", "Valor Total não pode ser menor que o Frete + Aluguel");


                CultureInfo culture = new CultureInfo("pt-BR");

                DateTime dtLocacao;
                if (string.IsNullOrEmpty(DataLocacao))
                    AddNotification("DataLocacao", "Data de Locacao obrigatório");
                else if (!DateTime.TryParseExact(DataLocacao, "yyyy/MM/dd", culture, DateTimeStyles.None, out dtLocacao))
                    AddNotification("DataLocacao", "Data de Locacao inválida");
                else
                    DataLocacaoConvertida = dtLocacao;

                DateTime dtDevolucao;
                if (string.IsNullOrEmpty(DataDevolucao))
                    AddNotification("DataDevolucao", "Data de Locacao obrigatório");
                else if (!DateTime.TryParseExact(DataDevolucao, "yyyy/MM/dd", culture, DateTimeStyles.None, out dtDevolucao))
                    AddNotification("DataDevolucao", "Data de Locacao inválida");
                else
                    DataDevolucaoConvertida = dtDevolucao;

                if (Equipamentos.Count() <= 0)
                    AddNotification("Equipamentos", "Equipamentos obrigatório");


                return Valid;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    public class EquipamentoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Cor { get; set; }
        public string Modelo { get; set; }
        public string Imagem { get; set; }
        public double SaldoEstoque { get; set; }
        public double ValorDiaria { get; set; }
    }
}
