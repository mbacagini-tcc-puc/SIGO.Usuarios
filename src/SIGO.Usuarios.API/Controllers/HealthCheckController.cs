using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SIGO.Usuarios.API.Controllers
{
    [Route("health")]
    [ApiController]
    [AllowAnonymous]
    public class HealthCheckController : ControllerBase
    {
        public IActionResult Check()
        {
            return Ok();
        }
    }
}