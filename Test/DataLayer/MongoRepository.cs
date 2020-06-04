using Test.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;


namespace Test.DataLayer
{
    public class MongoRepository
    {
        //delcaring mongo db
        private readonly IMongoDatabase _database;

        public MongoRepository(IOptions<Settings> settings)
        {
            try
            {
                var client = new MongoClient(settings.Value.ConnectionString);
                if (client != null)
                    _database = client.GetDatabase(settings.Value.Database);
            }
            catch (Exception ex)
            {
                throw new Exception("Can not access to MongoDb server.", ex);
            }

        }

        public IMongoCollection<Product> products => _database.GetCollection<Product>("Products");

    }
}