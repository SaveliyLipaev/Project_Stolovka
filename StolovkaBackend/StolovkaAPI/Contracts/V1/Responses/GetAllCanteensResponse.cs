using StolovkaWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StolovkaWebAPI.Contracts.V1.Responses
{
    public class GetAllCanteensResponse
    {

        public List<Canteen> Canteens { get; set; }
    }
}
