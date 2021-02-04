using FilmesVotacao.Domain.Interfaces.Commands;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmesVotacao.Domain.Commands.Voto.Input
{
    public class AdicionarVotoCommand : Notifiable, ICommandPadrao
    {
        public long IdUsuario { get; set; }
        public long IdFilme { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (IdUsuario <= 0)
                    AddNotification("IdUsuario", "IdUsuario é um campo obrigatório");

                if (IdFilme <= 0)
                    AddNotification("IdFilme", "IdFilme é um campo obrigatório");

                return Valid;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
