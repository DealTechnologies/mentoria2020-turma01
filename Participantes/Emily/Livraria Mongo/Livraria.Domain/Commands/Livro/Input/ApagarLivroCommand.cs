using Flunt.Notifications;
using Livraria.Domain.Interfaces.Commands;
using System;

namespace Livraria.Domain.Commands.Livro.Input
{
    public class ApagarLivroCommand : Notifiable, ICommandPadrao
    {
        public Guid Id { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (Id == Guid.Empty)
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