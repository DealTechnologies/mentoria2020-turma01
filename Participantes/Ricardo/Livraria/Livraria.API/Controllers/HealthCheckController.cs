using Microsoft.AspNetCore.Mvc;
using System;

namespace Livraria.API.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        [Route("v1/healthCheck")]
        public ActionResult<string> HealthCheck()
        {
            try
            {
                return "Livriaria API OK";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
