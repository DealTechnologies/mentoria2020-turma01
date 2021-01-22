using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using Votacao.Domain.Interfaces.Commands;

namespace Votacao.Domain.Commands.Usuario.Inputs
{
    public class ApagarUsuarioCommand : Notifiable, ICommandPadrao
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }

        public bool ValidarCommand()
        {
            try
            {
                if (Id <= 0)
                    AddNotification("Id", "Id é um campo obrigatório");

                return Valid;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
