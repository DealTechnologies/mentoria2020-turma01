using Voto.Domain.Interfaces.Commands;

namespace Voto.Domain.Commands.Filme.Output
{
    public class ApagarFilmeCommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public ApagarFilmeCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    
    }
}
