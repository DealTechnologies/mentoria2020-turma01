using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Votacao.Domain.Commands.Filme.Inputs;
using Votacao.Domain.Entidades;
using Votacao.Domain.Handlers;
using Votacao.Domain.Interfaces.Commands;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Domain.Queries;

namespace Votacao.Api.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeRepository _filmeRepository;
        private readonly FilmeHandler _handler;

        public FilmeController(IFilmeRepository filmeRepository, FilmeHandler handler)
        {
            _filmeRepository = filmeRepository;
            _handler = handler;
        }

        /// <summary>
        /// Filmes
        /// </summary>                
        /// <remarks><h2><b>Lista todos os Filmes.</b></h2></remarks>
        /// <response code="200">OK Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("v1/filmes")]
        [AllowAnonymous]
        public IEnumerable<FilmeQueryResult> Filmes()
        {
            return _filmeRepository.ListarAsync().Result;
        }

        /// <summary>
        /// Filmes
        /// </summary>                
        /// <remarks><h2><b>Consulta o Filme.</b></h2></remarks>
        /// <param name="id">Parâmetro requerido id do Filme</param>
        /// <response code="200">OK Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("v1/filmes/{id}")]
        [AllowAnonymous]
        public FilmeQueryResult Filme(long id)
        {
            return _filmeRepository.ObterPorIdAsync(id).Result;
        }

        /// <summary>
        /// Incluir Filme 
        /// </summary>                
        /// <remarks><h2><b>Incluir novo Filme na base de dados.</b></h2></remarks>
        /// <param name="command">Parâmetro requerido command de Insert</param>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [Route("v1/filmes")]
        [Authorize(Roles = "Visitante,Administrador")]
        public ICommandResult FilmeInserir([FromBody] AdicionarFilmeCommand command)
        {
            return _handler.Handler(command);
        }

        /// <summary>
        /// Alterar Filme
        /// </summary>        
        /// <remarks><h2><b>Alterar Filme na base de dados.</b></h2></remarks>
        /// <param name="id">Parâmetro requerido id do Filme</param>        
        /// <param name="command">Parâmetro requerido command de Update</param>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut]
        [Route("v1/filmes/{id}")]
        [Authorize(Roles = "Visitante,Administrador")]
        public ICommandResult FilmeAlterar(long id, [FromBody] AtualizarFilmeCommand command)
        {
            command.Id = id;
            return _handler.Handler(command);
        }

        /// <summary>
        /// Excluir Filme
        /// </summary>                
        /// <remarks><h2><b>Excluir Filme na base de dados.</b></h2></remarks>
        /// <param name="id">Parâmetro requerido id do Filme</param>        
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpDelete]
        [Route("v1/filmes/{id}")]
        [Authorize(Roles = "Visitante,Administrador")]
        public ICommandResult FilmeApagar(long id)
        {
            ApagarFilmeCommand command = new ApagarFilmeCommand() { Id = id };
            return _handler.Handler(command);
        }
    }
}
