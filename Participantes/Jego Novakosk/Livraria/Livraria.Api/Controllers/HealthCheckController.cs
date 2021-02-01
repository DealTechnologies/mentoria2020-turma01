using Microsoft.AspNetCore.Mvc;
using System;

namespace Livraria.Api.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {

        /// <summary>
        /// Health Check
        /// </summary>
        /// <remarks><h2><b>Afere a resposta deste contexto do serviço</b></h2></remarks>
        /// <response code="200">OK Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("v1/healthCheck")]
        public ActionResult<string> HelthCheck()
        {
            try
            {
                return "Livraria API";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
