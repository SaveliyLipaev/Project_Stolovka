using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace StolovkaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SimpleController : ControllerBase
    {
        [HttpGet]
        public int Get()
        {
            return 1;
        }
    }
}
