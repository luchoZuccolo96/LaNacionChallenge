using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ChallengeLaNacion.Controllers
{
    [Route("api/server")]
    [ApiController]
    public class StatusController : Controller
    {
        [HttpGet("status")]
        [SwaggerOperation("Obtiene el estado del servidor.")]
        public ActionResult Status()
        {
            return Ok("Servidor activo");
        }
    }
}
