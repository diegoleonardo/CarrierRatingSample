using MongoDB.Driver;

namespace CarrierRating.Data.DatabaseContext
{
    public interface IMongoDBContext
    {
        IMongoDatabase GetDatabase();
    }
}
