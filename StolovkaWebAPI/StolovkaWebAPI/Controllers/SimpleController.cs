using Microsoft.AspNetCore.Mvc;
using StolovkaWebAPI.Models;

namespace StolovkaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SimpleController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public SimpleController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public int Get()
        {
            return 1;
        }
    }
}
