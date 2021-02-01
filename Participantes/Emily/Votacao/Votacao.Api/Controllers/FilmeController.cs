using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Votacao.Domain.Commands.Filme.Input;
using Votacao.Domain.Handlers;
using Votacao.Domain.Interfaces.Commands;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Domain.Queries.FIlme;

namespace Votacao.Api.Controllers

{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeRepository _repository;
        private readonly FilmeHandler _handler;

        public FilmeController(IFilmeRepository repository, FilmeHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }
        /// <summary>
        /// Listar
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/livros")]

        public IEnumerable<FilmeQueryResult> Filmes()
        {
            return _repository.Listar();
        }
        /// <summary>
        /// Obter por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/livros/{id}")]

        public FilmeQueryResult Filme(long id)
        {
            return _repository.ObterPorId(id);
        }
        /// <summary>
        /// Inserir
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("v1/livros")]

        public ICommandResult FilmeInserir(long id, [FromBody] AdicionarFilmeCommand command)
        {
            
            return _handler.Handler(command);
        }

        /// <summary>
        /// Deletar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>

        [HttpDelete]
        [Route("v1/livros/{id}")]

        public ICommandResult FilmeApagar(long id, [FromBody] ApagarFilmeCommand command)
        {
            command.Id = id;
            return _handler.Handler(command);
        }

        [HttpPut]
        [Route("v1/filmes/{id}")]
        public ICommandResult FilmeAtualizar(long id, [FromBody] AtualizarFilmeCommand command)
        {
            command.Id = id;
            return _handler.Handler(command);
        }





    }
}