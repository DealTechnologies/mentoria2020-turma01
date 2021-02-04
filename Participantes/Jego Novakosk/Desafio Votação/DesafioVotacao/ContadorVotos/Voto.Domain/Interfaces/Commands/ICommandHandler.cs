using System;
using System.Collections.Generic;
using System.Text;

namespace Voto.Domain.Interfaces.Commands
{
    public interface ICommandHandler<T> where T : ICommandPadrao
    {
        ICommandResult Handler(T command);
    }
}
