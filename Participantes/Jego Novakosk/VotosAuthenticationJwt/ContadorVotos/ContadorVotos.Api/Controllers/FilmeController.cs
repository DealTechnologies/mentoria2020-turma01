using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voto.Domain.Commands.Filme.Input;
using Voto.Domain.Handlers;
using Voto.Domain.Interfaces.Commands;
using Voto.Domain.Interfaces.Handlers;
using Voto.Domain.Interfaces.Repositories;
using Voto.Domain.Queries.Filme;

namespace ContadorVotos.Api.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class FilmeController : ControllerBase
    {

        private readonly IFilmeRepository _repository;
        private readonly IFilmeHandler _handler;
        public FilmeController(IFilmeRepository repository, IFilmeHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }


        /// <summary>
        /// Buscar todos os Fimes 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/filmes")]
        public IEnumerable<FilmeQueryResult> Filmes()
        {
            return _repository.Listar();
        }

        /// <summary>
        /// Buscar por ID
        /// </summary>
        /// <param name="id">Informar o valor do ID</param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/filmes/{id}")]
        public FilmeQueryResult Filme(int id)
        {
            return _repository.ObterPorId(id);
        }

        /// <summary>
        /// Inserir Filme
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("v1/filmes")]
        public ICommandResult FilmeInserir([FromBody] AdicionarFilmeCommand command)
        {
            return _handler.Handler(command);
        }

        /// <summary>
        /// Atualizar Filme 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("v1/filmes/{id}")]
        public ICommandResult FilmeAtualizar(int id, [FromBody] AtualizarFilmeCommand command)
        {
            command.Id = id;
            return _handler.Handler(command);
        }

        /// <summary>
        /// Deletar Filme
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("v1/filmes/{id}")]
        public ICommandResult FilmeApagar(int id, [FromBody] ApagarFilmeCommand command)
        {
            command.Id = id;
            return _handler.Handler(command);
        }
    }
}
