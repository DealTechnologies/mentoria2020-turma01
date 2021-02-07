using Flunt.Notifications;
using Locadora.Domain.Interfaces.Commands;
using System;

namespace Locadora.Domain.Commands.Clientes.Inputs
{
    public class AutenticarClienteCommand : Notifiable, ICommandPadrao
    {
        public string Cpf { get; set; }
        public string Senha { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (string.IsNullOrEmpty(Cpf))
                    AddNotification("Cpf", "Cpf obrigatório");
                else if (Cpf.Length > 11)
                    AddNotification("Cpf", "Cpf maior que o esperado");

                if (string.IsNullOrEmpty(Senha))
                    AddNotification("Senha", "Senha obrigatória");
                else if (!(Senha.Length >= 3 && Senha.Length <= 6))
                    AddNotification("Senha", "Senha deve ser maior que 3 e menor que 6 digitos");

                return Valid;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
