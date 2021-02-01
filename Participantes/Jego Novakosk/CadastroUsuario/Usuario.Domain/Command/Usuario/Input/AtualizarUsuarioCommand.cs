using Flunt.Notifications;
using System;
using System.Text.Json.Serialization;
using Usuario.Domain.Interface.Commands;

namespace Usuario.Domain.Command.Usuario.Input
{
    public class AtualizarUsuarioCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool ValidarCommand()
        {
            try
            {
                if (Id < 0)
                {
                    AddNotification("Id", "Id e um campo Obgrigatorio");
                }

                if (string.IsNullOrEmpty(Nome))
                {
                    AddNotification("Nome", "Nome e um campo Obgrigatorio");
                }
                else if (Nome.Length > 50)
                {
                    AddNotification("Nome", "Nome e um campo maior que o esperado");
                }

                if (string.IsNullOrEmpty(CPF))
                {
                    AddNotification("CPF", "CPF e um campo Obgrigatorio");
                }
                else if (CPF.Length > 50)
                {
                    AddNotification("CPF", "Nome e um campo maior que o esperado");
                }

                if (string.IsNullOrEmpty(Email))
                {
                    AddNotification("Email", "Email e um campo Obgrigatorio");
                }
                else if (Email.Length > 50)
                {
                    AddNotification("Email", "Email e um campo maior que o esperado");
                }

                if (string.IsNullOrEmpty(Senha))
                {
                    AddNotification("Senha", "Senha e um campo Obgrigatorio");
                }
                else if (Senha.Length > 50)
                {
                    AddNotification("Senha", "Senha e um campo maior que o esperado");
                }

                return Valid;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}