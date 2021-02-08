using AutoMapper;
using Locadora.Domain.Commands.Clientes.Inputs;
using Locadora.Domain.Entidades;
using Locadora.Domain.Handlers;
using Locadora.Domain.Interfaces;
using Locadora.Domain.Interfaces.Commands;
using Locadora.Domain.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Locadora.Api.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ClienteHandler _handler;
        private readonly IMapper _mapper;

        public ClienteController(IUnitOfWork unitOfWork, ClienteHandler handler, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _handler = handler;
            _mapper = mapper;
        }

        /// <summary>
        /// Login
        /// </summary>                
        /// <remarks><h2><b>Autenticar os Clientes.</b></h2></remarks>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [Route("v1/login")]
        //[AllowAnonymous]
        public ICommandResult Login([FromBody] AutenticarClienteCommand command)
        {
            return _handler.Handler(command);
        }

        /// <summary>
        /// Clientes
        /// </summary>                
        /// <remarks><h2><b>Lista todos os Clientes.</b></h2></remarks>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("v1/clientes")]
        //[Authorize(Roles = "Cliente,Administrador")]
        public IEnumerable<ClienteQueryResult> Cliente()
        {
            var cliente = _unitOfWork.Clientes.ListarAsync().Result;
            return _mapper.Map<IEnumerable<ClienteQueryResult>>(cliente);
        }

        /// <summary>
        /// Clientes
        /// </summary>                
        /// <remarks><h2><b>Consulta o Cliente.</b></h2></remarks>
        /// <param name="id">Parâmetro requerido id do Cliente</param>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("v1/clientes/{id}")]
        //[Authorize(Roles = "Cliente,Administrador")]
        public ClienteQueryResult Cliente(Guid id)
        {
            var cliente = _unitOfWork.Clientes.ObterPorIdAsync(id).Result;
            return _mapper.Map<ClienteQueryResult>(cliente);
        }

        /// <summary>
        /// Incluir Cliente 
        /// </summary>                
        /// <remarks><h2><b>Incluir novo Cliente na base de dados.</b></h2></remarks>
        /// <param name="command">Parâmetro requerido command de Insert</param>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [Route("v1/clientes")]
        //[AllowAnonymous]
        public ICommandResult ClienteInserir([FromBody] AdicionarClienteCommand command)
        {
            return _handler.Handler(command);
        }

        /// <summary>
        /// Alterar Cliente
        /// </summary>        
        /// <remarks><h2><b>Alterar Cliente na base de dados.</b></h2></remarks>
        /// <param name="id">Parâmetro requerido id do Cliente</param>        
        /// <param name="command">Parâmetro requerido command de Update</param>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut]
        [Route("v1/clientes/{id}")]
        //[Authorize(Roles = "Cliente,Administrador")]
        public ICommandResult ClienteAlterar(Guid id, [FromBody] AtualizarClienteCommand command)
        {
            command.Id = id;
            return _handler.Handler(command);
        }

        /// <summary>
        /// Excluir Cliente
        /// </summary>                
        /// <remarks><h2><b>Excluir Cliente na base de dados.</b></h2></remarks>
        /// <param name="id">Parâmetro requerido id do Cliente</param>        
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpDelete]
        [Route("v1/clientes/{id}")]
        //[Authorize(Roles = "Administrador")]
        public ICommandResult ClienteApagar(Guid id)
        {
            ApagarClienteCommand command = new ApagarClienteCommand() { Id = id };
            return _handler.Handler(command);
        }
    }
}
