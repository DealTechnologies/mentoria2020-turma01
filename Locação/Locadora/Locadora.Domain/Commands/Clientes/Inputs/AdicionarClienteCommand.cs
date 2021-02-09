using Flunt.Notifications;
using Locadora.Domain.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Locadora.Domain.Commands.Clientes.Inputs
{
    public class AdicionarClienteCommand : Notifiable, ICommandPadrao
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public DateTime DataNascimentoConvertida { get; private set; }

        public bool ValidarCommand()
        {
            try
            {
                if (string.IsNullOrEmpty(Nome))
                    AddNotification("Nome", "Nome obrigatório");
                else if (Nome.Length > 50)
                    AddNotification("Nome", "Nome maior que o esperado");

                if (string.IsNullOrEmpty(Senha))
                    AddNotification("Senha", "Senha obrigatória");
                else if (!(Senha.Length >= 3 && Senha.Length <= 6))
                    AddNotification("Senha", "Senha deve ser maior que 3 e menor que 6 digitos");

                if (string.IsNullOrEmpty(Rg))
                    AddNotification("Rg", "Rg obrigatório");
                else if (Rg.Length > 8)
                    AddNotification("Rg", "Rg maior que o esperado");

                if (string.IsNullOrEmpty(Cpf))
                    AddNotification("Cpf", "Cpf obrigatório");
                else if (Cpf.Length > 11)
                    AddNotification("Cpf", "Cpf maior que o esperado");

                if (string.IsNullOrEmpty(Email))
                    AddNotification("Email", "Email obrigatório");
                else if (Email.Length > 50)
                    AddNotification("Email", "Email maior que o esperado");

                CultureInfo culture = new CultureInfo("pt-BR");
                DateTime dtNascimento;
                if (string.IsNullOrEmpty(DataNascimento))
                    AddNotification("DataNascimento", "Data de Nascimento obrigatório");
                else if (!DateTime.TryParseExact(DataNascimento, "yyyy/MM/dd", culture, DateTimeStyles.None, out dtNascimento))
                    AddNotification("DataNascimento", "Data de Nascimento inválida");
                else
                    DataNascimentoConvertida = dtNascimento;

                return Valid;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
