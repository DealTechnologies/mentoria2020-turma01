using FilmesVotacao.Domain.Interfaces.Commands;
using Flunt.Notifications;
using System;

namespace FilmesVotacao.Domain.Commands.Filme.Input
{
    public class ApagarFilmeCommand : Notifiable, ICommandPadrao
    {
        public long Id { get; set; }
        public bool ValidarCommand()
        {
            try
            {
                if (Id <= 0)
                    AddNotification("Id", "Id inválido!");
                return Valid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}