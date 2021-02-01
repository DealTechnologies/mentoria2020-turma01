using Votacao.Domain.Interfaces.Commands;

namespace Votacao.Domain.Commands.Filme.Outputs
{
    public class AdicionarFilmeCommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public AdicionarFilmeCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
