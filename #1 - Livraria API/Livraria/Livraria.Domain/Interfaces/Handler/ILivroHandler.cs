using Livraria.Domain.Commands.Livro.Input;
using Livraria.Infra.Interfaces.Commands;

namespace Livraria.Domain.Interfaces.Handler
{
    public interface ILivroHandler
    {
        ICommandResult Handle(AdicionarLivroCommand command);
        ICommandResult Handle(AtualizarLivroCommand command);
        ICommandResult Handle(ApagarLivroCommand command);
    }
}