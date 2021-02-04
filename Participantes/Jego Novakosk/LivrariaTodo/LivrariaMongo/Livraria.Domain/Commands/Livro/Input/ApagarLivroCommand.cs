using Flunt.Notifications;
using Livraria.Domain.Interfaces.Commands;
using MongoDB.Bson;
using System;

namespace Livraria.Domain.Commands.Livro.Input
{
    public class ApagarLivroCommand : Notifiable, ICommandPadrao
    {
        public string Id { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                // TRATAMENTO DE ERRO ID
                if (string.IsNullOrEmpty(Id.ToString()))
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
