﻿using Votacao.Domain.Interfaces.Commands;

namespace Votacao.Domain.Commands.Voto.Outputs
{
    public class VotarCommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public VotarCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
