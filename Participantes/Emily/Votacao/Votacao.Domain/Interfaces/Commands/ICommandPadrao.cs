using System;
using System.Collections.Generic;
using System.Text;

namespace Votacao.Domain.Interfaces.Commands
{
    public interface ICommandPadrao
    {
        bool ValidarCommand();
    }
}
