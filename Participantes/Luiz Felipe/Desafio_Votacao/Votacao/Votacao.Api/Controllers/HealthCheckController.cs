using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Votacao.Api.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class HealthCheckController : Controller
    {
        /// <summary>
        /// Health Check
        /// </summary>
        /// <remarks><h2>Verifica se a api está funcionando.</h2></remarks>
        /// <returns code="200"></returns>
        /// <returns code="500">Internal Server Error</returns>
        [HttpGet]
        [Route("v1/healthCheck")]
        public ActionResult<string> HealthCheck()
        {
            try
            {
                return "Votação API Ok";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
