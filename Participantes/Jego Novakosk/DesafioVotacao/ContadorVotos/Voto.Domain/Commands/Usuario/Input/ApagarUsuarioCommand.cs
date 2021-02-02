using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using Voto.Domain.Interfaces.Commands;

namespace Voto.Domain.Commands.Usuario.Input
{
    public class ApagarUsuarioCommand : Notifiable, ICommandPadrao
    {
        public int Id { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                //tratamento erro Id
                if (Id < 0)
                {
                    AddNotification("Id", "Id e um campo obrigatorio");
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
