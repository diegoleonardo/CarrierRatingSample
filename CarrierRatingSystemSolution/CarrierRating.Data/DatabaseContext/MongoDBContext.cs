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
            settings.Server = new MongoServerAddress("localhost", 27017);
            _client = new MongoClient(settings);

            _database = _client.GetDatabase("CarriersRatingSystem");
        }

        public IMongoDatabase GetDatabase()
        {
            return _database;
        }
    }
}
