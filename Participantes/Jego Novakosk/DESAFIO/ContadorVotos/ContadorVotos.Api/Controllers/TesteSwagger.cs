using Microsoft.AspNetCore.Mvc;
using System;

namespace ContadorVotos.Api.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class TesteSwagger : ControllerBase
    {

        [HttpGet]
        [Route("v1/testeSwagger")]
        public ActionResult<string> Teste()
        {
            try
            {
                return "teste de Swagger OK!";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
