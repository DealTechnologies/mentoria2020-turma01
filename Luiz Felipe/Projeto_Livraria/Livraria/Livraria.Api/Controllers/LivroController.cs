using Livraria.Domain.Interfaces.Repositories;
using Livraria.Domain.Queries.Livro;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Livraria.Api.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _repository;

        public LivroController(ILivroRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("v1/livros")]
        public IEnumerable<LivroQueryResult> Livros()
        {
            return _repository.Listar();
        }

        [HttpGet]
        [Route("v1/livros/{id}")]
        public LivroQueryResult Livro(long id)
        {
            return _repository.ObterPorId(id);
        }
    }
}
