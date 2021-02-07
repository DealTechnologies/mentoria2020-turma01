using Flunt.Notifications;
using Locadora.Domain.Interfaces.Commands;
using System;

namespace Locadora.Domain.Commands.Clientes.Inputs
{
    public class ApagarClienteCommand : Notifiable, ICommandPadrao
    {
        public Guid Id { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (Guid.Empty == Id)
                    AddNotification("Id", "Id obrigatório");

                return Valid;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
