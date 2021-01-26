using Voto.Domain.Commands.Votos.Input;
using Voto.Domain.Interfaces.Commands;

namespace Voto.Domain.Interfaces.Handlers
{
    public interface IVotosHandler : ICommandHandler<AdicionarVotosCommand>,
                                     ICommandHandler<AtualizarVotosCommand>,
                                     ICommandHandler<ApagarVotosCommand>
    {
    }
}
