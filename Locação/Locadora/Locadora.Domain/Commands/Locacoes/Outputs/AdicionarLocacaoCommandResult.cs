using Locadora.Domain.Interfaces.Commands;

namespace Locadora.Domain.Commands.Locacoes.Outputs
{
    public class AdicionarLocacaoCommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public AdicionarLocacaoCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
