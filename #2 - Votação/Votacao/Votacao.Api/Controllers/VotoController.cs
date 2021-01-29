using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Votacao.Domain.Command.Voto.Input;
using Votacao.Domain.Interfaces.Commands;
using Votacao.Domain.Interfaces.Handlers;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Domain.Query.Voto;

namespace Votacao.Api.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class VotoController : ControllerBase
    {
        private readonly IVotoRepository _repositorio;
        private readonly IVotoHandler _handler;

        public VotoController(IVotoRepository repositorio, IVotoHandler handler)
        {
            _repositorio = repositorio;
            _handler = handler;
        }

        /// <summary>
        /// Votos
        /// </summary>                
        /// <remarks><h2><b><i>Lista todos os Votos.</i></b></h2></remarks>
        /// <response code="200">OK Request</response>
        /// <response code="204">Not Content</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("v1/votos")]
        public List<VotoQueryResult> Votos()
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
        /// Voto
        /// </summary>                
        /// <remarks><h2><b>Consulta o Voto.</b></h2></remarks>
        /// <param name="id">Parâmetro requerido Id do Usuário</param>
        /// <response code="200">OK Request</response>
        /// <response code="204">Not Content</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("v1/votos/{id}")]
        public VotoQueryResult Voto(int id)
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
        /// Incluir Voto 
        /// </summary>                
        /// <remarks><h2><b>Incluir novo Voto na base de dados.</b></h2></remarks>
        /// <param name="command">Parâmetro requerido command de Insert</param>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [Route("v1/votos")]
        public ICommandResult VotoPost([FromBody]AdicionarVotoCommand command)
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
        /// Alterar Voto
        /// </summary>        
        /// <remarks><h2><b>Alterar Voto na base de dados.</b></h2></remarks> 
        /// <param name="id">Parâmetro requerido Id do Usuário</param>       
        /// <param name="command">Parâmetro requerido command de Update</param>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPatch]
        [Route("v1/votos/{id}")]
        public ICommandResult VotoPatch(int id, [FromBody]AtualizarVotoCommand command)
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
        /// Excluir Voto
        /// </summary>                
        /// <remarks><h2><b>Excluir Voto na base de dados.</b></h2></remarks>
        /// <param name="id">Parâmetro requerido Id do Usuário</param>       
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpDelete]
        [Route("v1/votos/{id}")]
        public ICommandResult VotoDelete(int id)
        {
            try
            {
                ApagarVotoCommand command = new ApagarVotoCommand() { Id = id };
                return _handler.Handle(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}