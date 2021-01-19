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

        /// <summary>
        /// Livros
        /// </summary>                
        /// <remarks><h2><b>Lista todos os Livros.</b></h2></remarks>
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
        /// <remarks><h2><b>Consulta o Livro.</b></h2></remarks>
        /// <param name="id">Parâmetro requerido id do Livro</param>
        /// <response code="200">OK Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("v1/livros/{id}")]
        public LivroQueryResult Livro(long id)
        {
            return _repository.ObterPorId(id);
        }
    }
}