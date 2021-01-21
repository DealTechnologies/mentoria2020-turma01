using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Interfaces.Commands
{
    public interface ICommanHandler<T> 
        where T : ICommandPadrao
    {
        ICommandResult Handler(T command);
    }
}
