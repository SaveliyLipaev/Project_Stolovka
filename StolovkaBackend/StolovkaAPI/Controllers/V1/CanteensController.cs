using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StolovkaWebAPI.Cache;
using StolovkaWebAPI.Contracts.V1;
using StolovkaWebAPI.Contracts.V1.Responses;
using StolovkaWebAPI.Services;

namespace StolovkaWebAPI.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CanteensController : Controller
    {
        private readonly ICanteensService _canteensService;
        private readonly IUriService _uriService;

        public CanteensController(ICanteensService canteensService, IUriService uriService)
        {
            _canteensService = canteensService;
            _uriService = uriService;
        }

        [HttpGet(ApiRoutes.Canteens.GetAll)]
        //[Cached(600)]
        public async Task<IActionResult> GetAll()
        {
            var canteens = await _canteensService.GetAllCanteens();

            return Ok(new GetAllCanteensResponse() { Canteens = canteens });
        }
    }
}