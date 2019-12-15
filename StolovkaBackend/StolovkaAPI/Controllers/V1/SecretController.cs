using Microsoft.AspNetCore.Mvc;
using StolovkaWebAPI.Filters;

namespace StolovkaWebAPI.Controllers.V1
{
    [ApiKeyAuth]
    public class SecretController : ControllerBase
    {
        [HttpGet("secret")]
        public IActionResult GetSecret()
        {
            return Ok("I have no secrets");
        }
    }
}