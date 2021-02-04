using System;
using System.Collections.Generic;
using System.Text;

namespace FilmesVotacao.Domain.Interfaces.Commands
{
    public interface ICommandPadrao
    {
        bool ValidarCommand();
    }
}
