namespace Usuario.Domain.Interface.Commands
{
    public interface ICommandHandler<T> where T : ICommandPadrao
    {
        ICommandResult Handler(T command);
    }
}
