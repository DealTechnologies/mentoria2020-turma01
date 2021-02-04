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
                // TRATAMENTO DE ERRO ID
                if (Id <= 0)
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
