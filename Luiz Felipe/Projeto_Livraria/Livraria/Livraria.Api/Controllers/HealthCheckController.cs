using Microsoft.AspNetCore.Mvc;
using System;

namespace Livraria.Api.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class HealthCheckController : Controller
    {
        /// <summary>
        /// Health Check
        /// </summary>
        /// <remarks><h2>Afere a resposta deste contexto do servico.</h2></remarks>
        /// <returns code="200"></returns>
        /// <returns code="500">Internal Serer Error</returns>
        [HttpGet]
        [Route("v1/healthCheck")]
        public ActionResult<string> HealthCheck()
        {
            try
            {
                return "Livraria API OK";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
