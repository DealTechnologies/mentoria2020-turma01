using System;
using System.Collections.Generic;
using System.Text;
using Voto.Domain.Commands.Usuario.Input;
using Voto.Domain.Interfaces.Commands;

namespace Voto.Domain.Interfaces.Handlers
{
    public interface IUsuarioHandler : ICommandHandler<AdicionarUsuarioCommand>,
                                       ICommandHandler<AtualizarUsuarioCommand>,
                                       ICommandHandler<ApagarUsuarioCommand>,
                                       ICommandHandler<LoginUsuarioCommand>
    {
    }
}
