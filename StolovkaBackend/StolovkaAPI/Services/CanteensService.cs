using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StolovkaWebAPI.Data;
using StolovkaWebAPI.Domain;

namespace StolovkaWebAPI.Services
{
    public class CanteensService : ICanteensService
    {
        private readonly StolovkaDbContext _dataContext;
        public CanteensService(StolovkaDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Canteen>> GetAllCanteens()
        {
            var queryable = _dataContext.Canteens;

            return await queryable.ToListAsync();
        }
    }
}
