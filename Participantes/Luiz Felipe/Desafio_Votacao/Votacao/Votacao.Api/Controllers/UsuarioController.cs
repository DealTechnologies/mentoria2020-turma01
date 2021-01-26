using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Votacao.Domain.Commands.Usuario.Inputs;
using Votacao.Domain.Handlers;
using Votacao.Domain.Interfaces.Commands;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Domain.Queries;

namespace Votacao.Api.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly UsuarioHandler _handler;

        public UsuarioController(IUsuarioRepository usuarioRepository, UsuarioHandler handler)
        {
            _usuarioRepository = usuarioRepository;
            _handler = handler;
        }

        /// <summary>
        /// Usuarios
        /// </summary>                
        /// <remarks><h2><b>Lista todos os Usuarios.</b></h2></remarks>
        /// <response code="200">OK Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("v1/usuarios")]
        public IEnumerable<UsuarioQueryResult> Usuarios()
        {
            return _usuarioRepository.Listar();
        }

        /// <summary>
        /// Usuarios
        /// </summary>                
        /// <remarks><h2><b>Consulta o Usuario.</b></h2></remarks>
        /// <param name="id">Parâmetro requerido id do Usuario</param>
        /// <response code="200">OK Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("v1/usuarios/{id}")]
        public UsuarioQueryResult Usuario(long id)
        {
            return _usuarioRepository.ObterPorId(id);
        }

        /// <summary>
        /// Incluir Usuario 
        /// </summary>                
        /// <remarks><h2><b>Incluir novo Usuario na base de dados.</b></h2></remarks>
        /// <param name="command">Parâmetro requerido command de Insert</param>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [Route("v1/usuarios")]
        public ICommandResult UsuarioInserir([FromBody] AdicionarUsuarioCommand command)
        {
            return _handler.Handler(command);
        }

        /// <summary>
        /// Alterar Usuario
        /// </summary>        
        /// <remarks><h2><b>Alterar Usuario na base de dados.</b></h2></remarks>
        /// <param name="id">Parâmetro requerido id do Usuario</param>        
        /// <param name="command">Parâmetro requerido command de Update</param>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut]
        [Route("v1/usuarios/{id}")]
        public ICommandResult UsuarioAlterar(long id, [FromBody] AtualizarUsuarioCommand command)
        {
            command.Id = id;
            return _handler.Handler(command);
        }

        /// <summary>
        /// Excluir Usuario
        /// </summary>                
        /// <remarks><h2><b>Excluir Usuario na base de dados.</b></h2></remarks>
        /// <param name="id">Parâmetro requerido id do Usuario</param>        
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpDelete]
        [Route("v1/usuarios/{id}")]
        public ICommandResult UsuarioApagar(long id)
        {
            ApagarUsuarioCommand command = new ApagarUsuarioCommand() { Id = id };
            return _handler.Handler(command);
        }
    }
}
