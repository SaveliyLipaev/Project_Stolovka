﻿using MongoDB.Driver;
using System;


namespace DBConnectionTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            MongoCRUD db = new MongoCRUD("StolovkaDB");
            db.Insert("users", new PersonModel { FirstName = "our obbgject", LastName = " dfsdds" });
        }
    }

    public class PersonModel
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    public class MongoCRUD
    {
        private IMongoDatabase db;

        public MongoCRUD(string database)
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);
        }

        public void Insert<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }
    }

}