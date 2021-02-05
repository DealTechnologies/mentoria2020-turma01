using Locadora.Domain.Interfaces.Commands;

namespace Locadora.Domain.Commands.Equipamentos.Outputs
{
    public class AtualizarEquipamentoCommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public AtualizarEquipamentoCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}