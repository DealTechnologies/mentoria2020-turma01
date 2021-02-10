using Flunt.Notifications;
using Locadora.Domain.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Locadora.Domain.Commands.Equipamentos.Inputs
{
    public class AtualizarEquipamentoCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Cor { get; set; }
        public string Modelo { get; set; }
        public string Imagem { get; set; }
        public double SaldoEstoque { get; set; }
        public double ValorDiaria { get;set; }
        public int QuantidadeAlugado { get;set; }
        public bool ValidarCommand()
        {
            if (Guid.Empty == Id)
                AddNotification("Id", "Id obrigatório");

            if (string.IsNullOrEmpty(Nome))
                AddNotification("Nome", "Nome obrigatório");
            else if (Nome.Length > 50)
                AddNotification("Nome", "Nome maior que o esperado");

            if (string.IsNullOrEmpty(Descricao))
                AddNotification("Descricao", "Descricao obrigatória");
            else if (!(Descricao.Length >= 3))
                AddNotification("Descricao", "Descricao deve ser maior que 3 e menor que 6 digitos");

            if (string.IsNullOrEmpty(Cor))
                AddNotification("Cor", "Cor obrigatório");
            else if (Cor.Length > 8)
                AddNotification("Cor", "Cor maior que o esperado");

            if (string.IsNullOrEmpty(Modelo))
                AddNotification("Modelo", "Modelo obrigatório");
            else if (Modelo.Length > 11)
                AddNotification("Modelo", "Modelo maior que o esperado");

            if (string.IsNullOrEmpty(Imagem))
                AddNotification("Imagem", "Imagem obrigatório");

            if (SaldoEstoque < 0)
                AddNotification("SaldoEstoque", "SaldoEstoque inválido!");

            if (ValorDiaria < 0)
                AddNotification("ValorDiaria", "ValorDiaria inválido!");

            if (QuantidadeAlugado <= 0)
                AddNotification("QuantidadeAlugado", "Quantidade alugado é um campo obrigatório");


            return Valid;
        }
    }
}