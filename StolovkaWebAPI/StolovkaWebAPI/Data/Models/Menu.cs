using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StolovkaWebAPI.Models
{
    public class Menu
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
