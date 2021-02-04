using FilmesVotacao.Domain.Interfaces.Commands;
using Flunt.Notifications;
using System;
using System.Text.Json.Serialization;

namespace FilmesVotacao.Domain.Commands.Usuario.Input
{
    public class AtualizarUsuarioCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool ValidarCommand()
        {
            try
            {
                if (Id <= 0)
                    AddNotification("Id", "Id é um campo obrigatório");

                if (string.IsNullOrEmpty(Nome))
                    AddNotification("Nome", "Nome é um campo obrigatório");
                else if (Nome.Length > 50)
                    AddNotification("Nome", "Nome maior do que o esperado");

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
