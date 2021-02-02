using System;
using System.Collections.Generic;
using System.Text;
using Voto.Domain.Interfaces.Commands;

namespace Voto.Domain.Commands.Votos.Output
{
    public class AdicionarVotosCommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public AdicionarVotosCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}