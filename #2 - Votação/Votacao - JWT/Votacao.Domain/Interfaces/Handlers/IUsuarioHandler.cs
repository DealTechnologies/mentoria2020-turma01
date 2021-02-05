using Votacao.Domain.Commands.Usuario.Input;
using Votacao.Domain.Interfaces.Commands;

namespace Votacao.Domain.Interfaces.Handlers
{
    public interface IUsuarioHandler : ICommandHandler<AdicionarUsuarioCommand>,
                                       ICommandHandler<AtualizarUsuarioCommand>,
                                       ICommandHandler<ApagarUsuarioCommand>,
                                       ICommandHandler<LogarUsuarioCommand>
    {
    }
}