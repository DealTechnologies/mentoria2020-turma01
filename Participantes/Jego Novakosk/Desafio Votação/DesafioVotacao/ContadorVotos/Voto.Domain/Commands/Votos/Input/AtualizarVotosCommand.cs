using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using Voto.Domain.Interfaces.Commands;

namespace Voto.Domain.Commands.Votos.Input
{
    public class AtualizarVotosCommand : Notifiable, ICommandPadrao
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdFilme { get; set; }

        public bool ValidarCommand()
        {

            try
            {
                if (Id < 0)
                {
                    AddNotification("Id", "Id e um campo obrigatorio");
                }

                if (IdUsuario < 0)
                {
                    AddNotification("IdUsuario", "IdUsuario e um campo obrigatorio");
                }

                if (IdFilme < 0)
                {
                    AddNotification("IdFilme", "IdFilme e um campo obrigatorio");
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

