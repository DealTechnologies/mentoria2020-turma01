using Microsoft.AspNetCore.Mvc;
using System;

namespace Votacao.Api.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]

    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        [Route("v1/HealthCheck")]
        public ActionResult<string> HealthCheck()
        {
            try
            {
                return "Votação API ok";

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}