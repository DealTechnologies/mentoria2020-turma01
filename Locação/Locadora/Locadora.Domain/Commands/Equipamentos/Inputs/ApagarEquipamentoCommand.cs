using Flunt.Notifications;
using Locadora.Domain.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Locadora.Domain.Commands.Equipamentos.Inputs
{
    public class ApagarEquipamentoCommand : Notifiable, ICommandPadrao
    {
        public bool ValidarCommand()
        {
            throw new NotImplementedException();
        }
    }
}
