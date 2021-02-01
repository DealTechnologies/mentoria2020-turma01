using Usuario.Domain.Command.Usuario.Input;
using Usuario.Domain.Interface.Commands;

namespace Usuario.Domain.Interface.Handlers
{
    public interface IUsuarioHandler :  ICommandHandler<AdicionarUsuarioCommand>,
                                        ICommandHandler<AtualizarUsuarioCommand>, 
                                        ICommandHandler<ApagarUsuarioCommand>
    {
    }
}
