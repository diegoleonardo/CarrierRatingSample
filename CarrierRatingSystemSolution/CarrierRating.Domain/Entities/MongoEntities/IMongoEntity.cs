using MongoDB.Bson;

namespace CarrierRating.Domain.Entities.MongoEntities
{
    public interface IMongoEntity
    {
        ObjectId Id { get; set; }
    }
}
