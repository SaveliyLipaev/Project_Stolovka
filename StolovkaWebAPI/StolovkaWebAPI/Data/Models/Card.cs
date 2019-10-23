using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StolovkaWebAPI.Models
{
    public class Card
    {
        public string Expires { get; set; }

        public string CardHolder { get; set; }

        public string Number { get; set; }
    }
}
