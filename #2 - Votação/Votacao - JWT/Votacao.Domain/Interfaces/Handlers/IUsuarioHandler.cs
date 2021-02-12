using Votacao.Domain.Commands.Usuario.Input;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Domain.Interfaces.Handlers
{
    public interface IUsuarioHandler
    {
        ICommandResult Handle(AdicionarUsuarioCommand command);
        ICommandResult Handle(AtualizarUsuarioCommand command);
        ICommandResult Handle(ApagarUsuarioCommand command);
        ICommandResult Handle(LogarUsuarioCommand command);
    }
}