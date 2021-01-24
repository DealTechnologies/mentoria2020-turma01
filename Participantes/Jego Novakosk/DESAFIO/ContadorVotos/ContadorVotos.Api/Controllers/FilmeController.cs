using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voto.Domain.Interfaces.Repositories;
using Voto.Domain.Queries.Filme;

namespace ContadorVotos.Api.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class FilmeController : ControllerBase
    {

        private readonly IFilmeRepository _filmeRepository;

        public FilmeController(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        /// <summary>
        /// Buscar todos os Fimes 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/filmes")]
        public IEnumerable<FilmeQueryResult> Filmes()
        {
            return _filmeRepository.Listar();
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
            return _filmeRepository.ObterPorId(id);
        }

    }
}
