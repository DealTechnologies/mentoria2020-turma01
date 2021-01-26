using Flunt.Notifications;
using System;
using Votacao.Domain.Interfaces.Commands;

namespace Votacao.Domain.Commands.Usuario.Inputs
{
    public class ApagarUsuarioCommand : Notifiable, ICommandPadrao
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (Id <= 0)
                    AddNotification("Id", Avisos.Campo_obrigatorio);

                return Valid;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
