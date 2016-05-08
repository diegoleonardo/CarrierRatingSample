using CarrierRating.Domain.Entities;
using MongoDB.Driver;

namespace CarrierRating.Data.DatabaseContext
{
    public class MongoDBContext : IMongoDBContext
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        public MongoDBContext()
        {
            MongoClientSettings settings = new MongoClientSettings();
            settings.Server = new MongoServerAddress("ds017582.mlab.com", 17582);
            var credencial = MongoCredential.CreateCredential("carriersratingsystem", "d.dummheit@gmail.com", "josel1to");
            settings.Credentials = new[] { credencial };
            _client = new MongoClient(settings);

            _database = _client.GetDatabase("carriersratingsystem");
            //_database.CreateCollection("User");
            //_client.GetDatabase("carriersratingsystem").GetCollection<User>("User");
        }

        public IMongoDatabase GetDatabase()
        {
            return _database;
        }
    }
}
