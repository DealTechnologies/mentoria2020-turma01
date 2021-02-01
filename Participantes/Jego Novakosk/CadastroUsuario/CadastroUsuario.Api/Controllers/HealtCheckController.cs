using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroUsuario.Api.Controllers
{
    [Consumes("Application/json")]
    [Produces("Application/json")]
    [ApiController]
    public class HealtCheckController : ControllerBase
    {
        [HttpGet]
        [Route("v1/healtCheck")]
        public ActionResult<string> HealtCheck()
        {
            try
            {
                return "Deu Boa";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
