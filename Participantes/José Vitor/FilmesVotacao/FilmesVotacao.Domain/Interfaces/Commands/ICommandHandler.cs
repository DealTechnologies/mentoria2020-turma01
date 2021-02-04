using System;
using System.Collections.Generic;
using System.Text;

namespace FilmesVotacao.Domain.Interfaces.Commands
{
    public interface ICommandHandler<T> where T: ICommandPadrao
    {
        ICommandResult Handler(T command);
    }
}
