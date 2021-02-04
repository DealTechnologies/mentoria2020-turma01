using Voto.Domain.Interfaces.Commands;

namespace Voto.Domain.Commands.Usuario.Output
{
    public class LoginUsuarioCommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public LoginUsuarioCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}