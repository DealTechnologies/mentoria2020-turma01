using FilmesVotacao.Domain.Interfaces.Commands;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmesVotacao.Domain.Commands.Usuario.Input
{
    public class LogarUsuarioCommand : Notifiable, ICommandPadrao
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
                    AddNotification("Login", "Login maior do que o esperado");

                if (string.IsNullOrEmpty(Senha))
                    AddNotification("Senha", "Senha é um campo obrigatório");
                else if (Senha.Length > 50)
                    AddNotification("Senha", "Senha maior do que o esperado");

                return Valid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

