using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Votacao.Domain.Command.Filme.Input;
using Votacao.Domain.Interfaces.Handlers;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Domain.Query.Filme;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Api.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeRepository _repositorio;
        private readonly IFilmeHandler _handler;

        public FilmeController(IFilmeRepository repositorio, IFilmeHandler handler)
        {
            _repositorio = repositorio;
            _handler = handler;
        }

        /// <summary>
        /// Filmes
        /// </summary>                
        /// <remarks><h2><b><i>Lista todos os Filmes.</i></b></h2></remarks>
        /// <response code="200">OK Request</response>
        /// <response code="204">Not Content</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("v1/filmes")]
        public List<FilmeQueryResult> Filmes()
        {
            try
            {
                return _repositorio.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Filme
        /// </summary>                
        /// <remarks><h2><b>Consulta o Filme.</b></h2></remarks>
        /// <param name="id">Parâmetro requerido Id do Filme</param>
        /// <response code="200">OK Request</response>
        /// <response code="204">Not Content</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("v1/filmes/{id}")]
        public FilmeQueryResult Filme(int id)
        {
            try
            {
                return _repositorio.Obter(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Incluir Filme 
        /// </summary>                
        /// <remarks><h2><b>Incluir novo Filme na base de dados.</b></h2></remarks>
        /// <param name="command">Parâmetro requerido command de Insert</param>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [Route("v1/filmes")]
        public ICommandResult FilmePost([FromBody]AdicionarFilmeCommand command)
        {
            try
            {
                return _handler.Handle(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Alterar Filme
        /// </summary>        
        /// <remarks><h2><b>Alterar Filme na base de dados.</b></h2></remarks> 
        /// <param name="id">Parâmetro requerido Id do Filme</param>       
        /// <param name="command">Parâmetro requerido command de Update</param>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut]
        [Route("v1/filmes/{id}")]
        public ICommandResult FilmePut(int id, [FromBody]AtualizarFilmeCommand command)
        {
            try
            {
                command.Id = id;
                return _handler.Handle(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Excluir Filme
        /// </summary>                
        /// <remarks><h2><b>Excluir Filme na base de dados.</b></h2></remarks>
        /// <param name="id">Parâmetro requerido Id do Filme</param>       
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpDelete]
        [Route("v1/filmes/{id}")]
        public ICommandResult FilmeDelete(int id)
        {
            try
            {
                ApagarFilmeCommand command = new ApagarFilmeCommand() { Id = id };
                return _handler.Handle(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}