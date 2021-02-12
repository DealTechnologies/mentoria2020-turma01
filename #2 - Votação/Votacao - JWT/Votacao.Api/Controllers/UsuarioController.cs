using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Votacao.Api.Services;
using Votacao.Domain.Commands.Usuario.Input;
using Votacao.Domain.Interfaces.Handlers;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Domain.Query.Usuario;
using Votacao.Infra.Interfaces.Commands;

namespace Votacao.Api.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;
        private readonly IUsuarioHandler _handler;
        private readonly TokenJWTService _tokenJWTService;

        public UsuarioController(IUsuarioRepository repository, IUsuarioHandler handler, TokenJWTService tokenJWTService)
        {
            _repository = repository;
            _handler = handler;
            _tokenJWTService = tokenJWTService;
        }

        /// <summary>
        /// Usuários
        /// </summary>                
        /// <remarks><h2><b><i>Lista todos os Usuários.</i></b></h2></remarks>
        /// <response code="200">OK Request</response>
        /// <response code="204">Not Content</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("v1/usuarios")]
        public List<UsuarioQueryResult> Usuarios()
        {
            try
            {
                return _repository.Listar();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Usuário
        /// </summary>                
        /// <remarks><h2><b>Consulta o Usuário.</b></h2></remarks>
        /// <param name="id">Parâmetro requerido Id do Usuário</param>
        /// <response code="200">OK Request</response>
        /// <response code="204">Not Content</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("v1/usuarios/{id}")]
        public UsuarioQueryResult Usuario(int id)
        {
            try
            {
                return _repository.Obter(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Incluir Usuário 
        /// </summary>                
        /// <remarks><h2><b>Incluir novo Usuário na base de dados.</b></h2></remarks>
        /// <param name="command">Parâmetro requerido command de Insert</param>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [Route("v1/usuarios")]
        public ICommandResult UsuarioPost([FromBody] AdicionarUsuarioCommand command)
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
        /// Alterar Usuário
        /// </summary>        
        /// <remarks><h2><b>Alterar Usuário na base de dados.</b></h2></remarks>   
        /// <param name="id">Parâmetro requerido Id do Usuário</param>     
        /// <param name="command">Parâmetro requerido command de Update</param>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut]
        [Route("v1/usuarios/{id}")]
        public ICommandResult UsuarioPut(int id, [FromBody] AtualizarUsuarioCommand command)
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
        /// Excluir Usuário
        /// </summary>                
        /// <remarks><h2><b>Excluir Usuário na base de dados.</b></h2></remarks> 
        /// <param name="id">Parâmetro requerido Id do Usuário</param>     
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpDelete]
        [Route("v1/usuarios/{id}")]
        public ICommandResult UsuarioDelete(int id)
        {
            try
            {
                ApagarUsuarioCommand command = new ApagarUsuarioCommand() { Id = id };
                return _handler.Handle(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Logar Usuário 
        /// </summary>                
        /// <remarks><h2><b>Efetua login do Usuário.</b></h2></remarks>
        /// <param name="command">Parâmetro requerido command de Login</param>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [AllowAnonymous]
        [HttpPost]
        [Route("v1/usuarios/login")]
        public ICommandResult UsuarioLogin([FromBody] LogarUsuarioCommand command)
        {
            try
            {
                var result = _handler.Handle(command);

                var tokenJWT = _tokenJWTService.GenerateToken((UsuarioQueryResult)result.Data);

                result.Data = tokenJWT;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}