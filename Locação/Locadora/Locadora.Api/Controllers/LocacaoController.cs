using AutoMapper;
using Locadora.Domain.Commands.Locacoes.Inputs;
using Locadora.Domain.Handlers;
using Locadora.Domain.Interfaces;
using Locadora.Domain.Interfaces.Commands;
using Locadora.Domain.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Api.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class LocacaoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly LocacaoHandler _handler;
        private readonly IMapper _mapper;

        public LocacaoController(IUnitOfWork unitOfWork, LocacaoHandler handler, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _handler = handler;
            _mapper = mapper;
        }

        /// <summary>
        /// Locações
        /// </summary>                
        /// <remarks><h2><b>Lista todos as Locações.</b></h2></remarks>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("v1/locacoes")]
        [Authorize(Roles = "Cliente")]
        public IEnumerable<LocacaoQueryResult> Locacoes()
        {
            var locacoes = _unitOfWork.Locacoes.ListarAsync().Result;
            return _mapper.Map<IEnumerable<LocacaoQueryResult>>(locacoes);
        }

        /// <summary>
        /// Locação
        /// </summary>                
        /// <remarks><h2><b>Consulta a Locação.</b></h2></remarks>
        /// <param name="id">Parâmetro requerido id do Locação</param>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("v1/locacoes/{id}")]
        [Authorize(Roles = "Cliente")]
        public LocacaoQueryResult Locacao(Guid id)
        {
            var locacao = _unitOfWork.Locacoes.ObterPorIdAsync(id).Result;
            return _mapper.Map<LocacaoQueryResult>(locacao);
        }

        /// <summary>
        /// Incluir Locacao 
        /// </summary>                
        /// <remarks><h2><b>Incluir nova Locacao na base de dados.</b></h2></remarks>
        /// <param name="command">Parâmetro requerido command de Insert</param>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [Route("v1/locacoes")]
        [Authorize(Roles = "Cliente")]
        public ICommandResult LocacaoInserir([FromBody] AdicionarLocacaoCommand command)
        {
            return _handler.Handler(command);
        }
    }
}
