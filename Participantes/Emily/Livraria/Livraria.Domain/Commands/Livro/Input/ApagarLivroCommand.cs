using Flunt.Notifications;
using Livraria.Domain.Interfaces.Commands;
using System;

namespace Livraria.Domain.Commands.Livro.Input
{
    public class ApagarLivroCommand : Notifiable, ICommandPadrao
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