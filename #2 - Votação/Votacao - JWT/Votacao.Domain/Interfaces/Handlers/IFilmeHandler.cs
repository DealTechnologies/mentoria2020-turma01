using Votacao.Domain.Command.Filme.Input;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Domain.Interfaces.Handlers
{
    public interface IFilmeHandler
    {
        ICommandResult Handle(AdicionarFilmeCommand command);
        ICommandResult Handle(AtualizarFilmeCommand command);
        ICommandResult Handle(ApagarFilmeCommand command);
    }
}