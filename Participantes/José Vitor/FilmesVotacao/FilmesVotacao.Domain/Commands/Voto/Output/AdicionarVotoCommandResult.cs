using FilmesVotacao.Domain.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmesVotacao.Domain.Commands.Voto.Output
{
    public class AdicionarVotoCommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public AdicionarVotoCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
