using Flunt.Notifications;
using Locadora.Domain.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Locadora.Domain.Commands.Equipamentos.Inputs
{
    public class ApagarEquipamentoCommand : Notifiable, ICommandPadrao
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
