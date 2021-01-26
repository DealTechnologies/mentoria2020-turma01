using Livraria.Domain.Commands.Livro.Input;
using Livraria.Domain.Handlers;
using Livraria.Domain.Interfaces.Commands;
using Livraria.Domain.Interfaces.Repositories;
using Livraria.Domain.Queries.Livro;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Livraria.API.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _repository;
        private readonly LivroHandler _handler;

        public LivroController(ILivroRepository repository, LivroHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/livros")]

        public IEnumerable<LivroQueryResult> Livros()
        {
            return _repository.Listar();
        }

        [HttpGet]
        [Route("v1/livros/{id}")]

        public LivroQueryResult Livros(long id)
        {
            return _repository.ObterPorId(id);
        }

        [HttpPost]
        [Route("v1/livros")]

        public ICommandResult LivroInserir([FromBody] AdicionarLivroCommand command)
        {
            return _handler.Handler(command);
        }

        [HttpPut]
        [Route("v1/livros/{id}")]

        public ICommandResult LivroAlterar(long id, [FromBody] AtualizarLivroCommand command)
        {
            command.Id = id;
            return _handler.Handler(command);
        }

        [HttpDelete]
        [Route("v1/livros/{id}")]

        public ICommandResult LivroApagar(long id)
        {
            ApagarLivroCommand command = new ApagarLivroCommand() { Id = id };
            return _handler.Handler(command);
        }
    }
}
