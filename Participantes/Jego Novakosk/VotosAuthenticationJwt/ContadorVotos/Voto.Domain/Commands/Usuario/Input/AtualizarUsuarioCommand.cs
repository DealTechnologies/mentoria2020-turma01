using Flunt.Notifications;
using System.Text.Json.Serialization;
using Voto.Domain.Interfaces.Commands;

namespace Voto.Domain.Commands.Usuario.Input
{
    public class AtualizarUsuarioCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public bool ValidarCommand()
        {
            if (Id < 0)
            {
                AddNotification("Id", "Id e um campo obrigatorio");
            }

            if (string.IsNullOrEmpty(Nome))
            {
                AddNotification("Nome", "Nome e um campo obrigatorio");
            }else if (Nome.Length > 50)
            {
                AddNotification("Nome", "Campo maior que o esperado");
            }

            if (string.IsNullOrEmpty(Login))
            {
                AddNotification("Login", "Login e um campo obrigatori");
            }
            else if (Login.Length > 50)
            {
                AddNotification("Login", "Campo maior que o esperado");
            }

            if (string.IsNullOrEmpty(Senha))
            {
                AddNotification("Senha", "Senha e um campo obrigatori");
            }
            else if (Senha.Length > 50)
            {
                AddNotification("Senha", "Campo maior que o esperado");
            }

            return Valid;
        }
    }
}
