using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Interfaces.Commands
{
    public interface ICommandPadrao
    {
        bool ValidarCommand();
    }
}
