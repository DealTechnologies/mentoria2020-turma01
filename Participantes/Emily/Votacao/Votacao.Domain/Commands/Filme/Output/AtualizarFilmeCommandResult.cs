﻿using System;
using System.Collections.Generic;
using System.Text;
using Votacao.Domain.Interfaces.Commands;

namespace Votacao.Domain.Commands.Filme.Output
{
    public class AtualizarFilmeCommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public AtualizarFilmeCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
