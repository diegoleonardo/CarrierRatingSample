using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CarrierRating.Domain.Entities.MongoEntities
{
    public class MongoEntity : IMongoEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public DateTime CreationDate { get; }
        public MongoEntity()
        {
            CreationDate = DateTime.Now;
        }
        public string GetStringId()
        {
            return Id.ToString();
        }
    }
}
