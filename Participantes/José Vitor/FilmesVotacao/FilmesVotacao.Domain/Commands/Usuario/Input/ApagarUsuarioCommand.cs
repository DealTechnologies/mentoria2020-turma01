using FilmesVotacao.Domain.Interfaces.Commands;
using Flunt.Notifications;
using System;

namespace FilmesVotacao.Domain.Commands.Usuario.Input
{
    public class ApagarUsuarioCommand : Notifiable, ICommandPadrao
    {
        public long Id { get; set; }
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