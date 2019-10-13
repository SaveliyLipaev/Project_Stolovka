using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StolovkaWebAPI.Models
{
    public class CanteenContext
    {
        private readonly IMongoDatabase _database = null;

        public CanteenContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Canteen> Canteens
        {
            get
            {
                return _database.GetCollection<Canteen>("Canteen");
            }
        }
    }
}
