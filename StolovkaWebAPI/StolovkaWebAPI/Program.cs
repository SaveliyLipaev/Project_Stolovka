using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace StolovkaWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MongoCRUD db = new MongoCRUD("StolovkaDB");
            CreateHostBuilder(args).Build().Run();
        }

        public class MongoCRUD
        {
            private IMongoDatabase db;

            public MongoCRUD(string database)
            {
                var client = new MongoClient();
                db = client.GetDatabase(database);
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
