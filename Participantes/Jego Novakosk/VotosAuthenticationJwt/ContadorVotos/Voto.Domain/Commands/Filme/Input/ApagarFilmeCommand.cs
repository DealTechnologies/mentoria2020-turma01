using Flunt.Notifications;
using System;
using Voto.Domain.Interfaces.Commands;

namespace Voto.Domain.Commands.Filme.Input
{
    public class ApagarFilmeCommand : Notifiable, ICommandPadrao
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

