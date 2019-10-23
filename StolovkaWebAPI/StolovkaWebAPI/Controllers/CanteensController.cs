using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StolovkaWebAPI.Models;

namespace StolovkaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanteensController : ControllerBase
    {
        private readonly ICanteenRepository _canteenRepository;

        public CanteensController(ICanteenRepository canteenRepository)
        {
            _canteenRepository = canteenRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Canteen>> Get()
        {
            return await _canteenRepository.GetAllItems();
        }

        [HttpGet("{id}")]
        public async Task<Canteen> Get(string id)
        {
            return await _canteenRepository.GetItem(id) ?? new Canteen();
        }

        [HttpPost]
        public void Post([FromBody] Canteen newCanteen)
        {
            _canteenRepository.AddItem(new Canteen
            {
                Id = newCanteen.Id,
                Name = newCanteen.Name,
                Address = newCanteen.Address,
                OpenHours = newCanteen.OpenHours,
                CloseHours = newCanteen.CloseHours,
                Menu = newCanteen.Menu,
            });
        }
    }
}