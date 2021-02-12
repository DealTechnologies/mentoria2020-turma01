using Votacao.Domain.Command.Voto.Input;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Domain.Interfaces.Handlers
{
    public interface IVotoHandler
    {
        ICommandResult Handle(AdicionarVotoCommand command);
        ICommandResult Handle(AtualizarVotoCommand command);
        ICommandResult Handle(ApagarVotoCommand command);
    }
}