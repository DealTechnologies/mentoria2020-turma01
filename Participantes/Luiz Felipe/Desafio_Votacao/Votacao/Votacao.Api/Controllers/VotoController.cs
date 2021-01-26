using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Votacao.Domain.Commands.Voto.Inputs;
using Votacao.Domain.Handlers;
using Votacao.Domain.Interfaces.Commands;
using Votacao.Domain.Interfaces.Repositories;

namespace Votacao.Api.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class VotoController : ControllerBase
    {
        private readonly VotoHandler _handler;

        public VotoController(VotoHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Votar
        /// </summary>                
        /// <remarks><h2><b>Votar no filme escolhido.</b></h2></remarks>
        /// <param name="command">Parâmetro requerido command de Insert</param>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [Route("v1/votar")]
        public ICommandResult Votar([FromBody] VotarCommand command)
        {
            return _handler.Handler(command);
        }
    }
}
