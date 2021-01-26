using Flunt.Notifications;
using System;
using Votacao.Domain.Interfaces.Commands;

namespace Votacao.Domain.Commands.Usuario.Inputs
{
    public class AutenticarUsuarioCommand : Notifiable, ICommandPadrao
    {
        public string Login { get; set; }
        public string Senha { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (string.IsNullOrEmpty(Login))
                    AddNotification("Login", "Login é um campo obrigatório");
                else if (Login.Length > 50)
                    AddNotification("Login", "Login maior que o esperado");

                if (string.IsNullOrEmpty(Senha))
                    AddNotification("Senha", "Senha é um campo obrigatório");
                else if (!(Senha.Length >= 3 && Senha.Length <= 6))
                    AddNotification("Senha", "Senha maior que o esperado");

                return Valid;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
