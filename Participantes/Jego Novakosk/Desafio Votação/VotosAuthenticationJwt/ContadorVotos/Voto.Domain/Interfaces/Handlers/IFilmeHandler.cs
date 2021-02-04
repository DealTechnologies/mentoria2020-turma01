using Voto.Domain.Commands.Filme.Input;
using Voto.Domain.Interfaces.Commands;

namespace Voto.Domain.Interfaces.Handlers
{
    public interface IFilmeHandler :  ICommandHandler<AdicionarFilmeCommand>,
                                      ICommandHandler<AtualizarFilmeCommand>,
                                      ICommandHandler<ApagarFilmeCommand>
    {
    }
}
