using Votacao.Domain.Interfaces.Commands;

namespace Votacao.Domain.Commands.Usuario.Outputs
{
    public class AtualizarUsuarioCommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public AtualizarUsuarioCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
