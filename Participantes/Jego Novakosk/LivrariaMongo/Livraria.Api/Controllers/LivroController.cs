using Livraria.Domain.Commands.Livro.Input;
using Livraria.Domain.Commands.Livro.Output;
using Livraria.Domain.Handlers;
using Livraria.Domain.Interfaces.Commands;
using Livraria.Domain.Interfaces.Repositories;
using Livraria.Domain.Queries.Livro;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Livraria.Api.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepositoryMongo _repository;
        private readonly LivroHandler _handler;

        public LivroController(ILivroRepositoryMongo repository, LivroHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }


        /// <summary>
        /// Livros
        /// </summary>
        /// <remarks><h2><b>Listar todos os Livros</b></h2></remarks>
        /// <response code="200">OK Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("v1/livros")]
        public IEnumerable<LivroQueryResult> Livros()
        {
            return _repository.Listar();
        }

        /// <summary>
        /// Livro
        /// </summary>
        /// <remarks><h2><b>Consultar o livro</b></h2></remarks>
        /// <param name="id">Parametro requerico id do livro</param>
        /// <response code="200">OK Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("v1/livros/{id}")]
        public LivroQueryResult Livro(string id)
        {
            return _repository.ObterPorID(id);
        }

        /// <summary>
        /// Incluir Livro 
        /// </summary>                
        /// <remarks><h2><b>Incluir novo Livro na base de dados.</b></h2></remarks>
        /// <param name="command">Parâmetro requerido command de Insert</param>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [Route("v1/livros")]
        public ICommandResult LivroInserir([FromBody] AdicionarLivroCommand command)
        {
            return _handler.Handler(command);
        }

        /// <summary>
        /// Alterar Livro
        /// </summary>        
        /// <remarks><h2><b>Alterar Livro na base de dados.</b></h2></remarks>
        /// <param name="id">Parâmetro requerido id do Livro</param>        
        /// <param name="command">Parâmetro requerido command de Update</param>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut]
        [Route("v1/livros/{id}")]
        public ICommandResult LivroAtualizar(string id, [FromBody] AtualizarLivroCommand command)
        {
            if (id.Length >= 24)
            {
                command.Id = id;
                return _handler.Handler(command);
            }

            var retorno = new AtualizarLivroCommandResult(false, "Id invalido esperado Id com 24 caracteres", new { });

            return retorno;
           
        }

        // <summary>
        /// Excluir Livro
        /// </summary>                
        /// <remarks><h2><b>Excluir Livro na base de dados.</b></h2></remarks>
        /// <param name="id">Parâmetro requerido id do Livro</param>        
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpDelete]
        [Route("v1/livros/{id}")]
        public ICommandResult LivroDeletar(string id)
        {
            ApagarLivroCommand command = new ApagarLivroCommand() { Id = id };
            return _handler.Handler(command);
        }
    }
}
