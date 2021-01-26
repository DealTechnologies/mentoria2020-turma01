using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voto.Domain.Commands.Votos.Input;
using Voto.Domain.Handlers;
using Voto.Domain.Interfaces.Commands;
using Voto.Domain.Interfaces.Handlers;
using Voto.Domain.Interfaces.Repositories;
using Voto.Domain.Queries.Votos;

namespace ContadorVotos.Api.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class VotosController : ControllerBase
    {
        private readonly IVotoRepository _repository;

        private readonly IVotosHandler _handler;

        public VotosController(IVotoRepository repository, IVotosHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }
        /// <summary>
        /// Buscar todos Votos 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/votos")]
        public IEnumerable<VotosQueryResult> Votos()
        {
            return _repository.Listar();
        }

        /// <summary>
        /// Buscar voto por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/votos/{id}")]
        public VotosQueryResult Filme(int id)
        {
            return _repository.ObterPorId(id);
        }

        /// <summary>
        /// Inseri Novo Voto
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("v1/votos")]
        public ICommandResult VotoInserir([FromBody] AdicionarVotosCommand command)
        {
            return _handler.Handler(command);
        }

        /// <summary>
        /// Atualizar Voto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("v1/votos/{id}")]
        public ICommandResult VotoAtualizatr(int id,[FromBody] AtualizarVotosCommand command)
        {
            return _handler.Handler(command);
        }

        /// <summary>
        /// Deletar Voto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("v1/votos/{id}")]
        public ICommandResult VotoDeletar(int id, [FromBody] ApagarVotosCommand command)
        {
            command.Id = id;
            return _handler.Handler(command);
        }
    }
}
