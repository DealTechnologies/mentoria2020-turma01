using Votacao.Domain.Command.Filme.Input;
using Votacao.Domain.Interfaces.Commands;

namespace Votacao.Domain.Interfaces.Handlers
{
    public interface IFilmeHandler : ICommandHandler<AdicionarFilmeCommand>,
                                     ICommandHandler<AtualizarFilmeCommand>,
                                     ICommandHandler<ApagarFilmeCommand>
    {
    }
}