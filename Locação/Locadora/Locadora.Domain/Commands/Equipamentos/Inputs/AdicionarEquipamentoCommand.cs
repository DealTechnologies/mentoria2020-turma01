using Flunt.Notifications;
using Locadora.Domain.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Locadora.Domain.Commands.Equipamentos.Inputs
{
    public class AdicionarEquipamentoCommand : Notifiable, ICommandPadrao
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Cor { get; set; }
        public string Modelo { get; set; }
        public string Imagem { get; set; }
        public double SaldoEstoque { get; set; }
        public double ValorDiaria { get; set; }
        public int QuantidadeAlugado { get; set; }
        public bool ValidarCommand()
        {
            try
            {
                if (string.IsNullOrEmpty(Nome))
                    AddNotification("Nome", "Nome é um campo obrigatório");
                else if (Nome.Length > 50)
                    AddNotification("Nome", "Nome maior que o esperado");

                if (string.IsNullOrEmpty(Descricao))
                    AddNotification("Descricao", "Descricao é um campo obrigatório");
                else if (Descricao.Length > 50)
                    AddNotification("Descricao", "Descricao maior que o esperado");

                if (string.IsNullOrEmpty(Cor))
                    AddNotification("Cor", "Cor é um campo obrigatório");

                if (string.IsNullOrEmpty(Modelo))
                    AddNotification("Modelo", "Modelo é um campo obrigatório");
                else if (Modelo.Length > 50)
                    AddNotification("Modelo", "Modelo maior que o esperado");

                if (string.IsNullOrEmpty(Imagem))
                    AddNotification("imagem", "imagem é um campo obrigatório");

                if (SaldoEstoque <= 0)
                    AddNotification("SaldoEstoque", "SaldoEstoque é um campo obrigatório");

                if (ValorDiaria <= 0)
                    AddNotification("ValorDiaria", "ValorDiaria é um campo obrigatório");
                
                if (QuantidadeAlugado <= 0)
                    AddNotification("QuantidadeAlugado", "Quantidade alugado é um campo obrigatório");


                return Valid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    }