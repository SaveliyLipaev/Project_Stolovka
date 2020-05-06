using StolovkaWebAPI.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StolovkaWebAPI.Services
{
    public interface ICanteensService
    {
        Task<List<Canteen>> GetAllCanteens();
    }
}
