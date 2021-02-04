using FilmesVotacao.Domain.Interfaces.Commands;

namespace FilmesVotacao.Domain.Commands.Usuario.Output
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