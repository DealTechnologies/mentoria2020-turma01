using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using Voto.Domain.Interfaces.Commands;

namespace Voto.Domain.Commands.Votos.Input
{
    public class ApagarVotosCommand : Notifiable, ICommandPadrao
    {
        public int Id { get; set; }
        public bool ValidarCommand()
        {
            try
            {
                if (Id < 0)
                {
                    AddNotification("Id", "Id é um campo obrigatorio");
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
