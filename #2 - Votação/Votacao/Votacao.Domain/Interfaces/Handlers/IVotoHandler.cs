using Votacao.Domain.Command.Voto.Input;
using Votacao.Domain.Interfaces.Commands;

namespace Votacao.Domain.Interfaces.Handlers
{
    public interface IVotoHandler : ICommandHandler<AdicionarVotoCommand>,
                                    ICommandHandler<AtualizarVotoCommand>,
                                    ICommandHandler<ApagarVotoCommand>
    {
    }
}