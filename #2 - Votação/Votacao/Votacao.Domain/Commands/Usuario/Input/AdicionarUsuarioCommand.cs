using Flunt.Notifications;
using System.Text.RegularExpressions;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Domain.Commands.Usuario.Input
{
    public class AdicionarUsuarioCommand : Notifiable, ICommandPadrao
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public bool ValidarCommand()
        {
            if (string.IsNullOrEmpty(Nome))
                AddNotification("Nome", "Nome é um campo obrigatório");
            else if (Nome.Length > 50)
                AddNotification("Nome", "Nome maior que o esperado");

            if (string.IsNullOrEmpty(Login))
                AddNotification("Login", "Login é um campo obrigatório");
            else if (Login.Length > 50)
                AddNotification("Login", "Login maior que o esperado");
            else if (!ValidarEmail(Login))
                AddNotification("Login", "Login não é um Email válido");

            if (string.IsNullOrEmpty(Senha))
                AddNotification("Senha", "Senha é um campo obrigatório");
            else if (Senha.Length > 50)
                AddNotification("Senha", "Senha maior que o esperado");

            return Valid;
        }

        public bool ValidarEmail(string email) => Regex.IsMatch(email, @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
    }
}