using CarrierRating.Domain.DTO;
using CarrierRating.Domain.Entities.MongoEntities;
using CarrierRating.Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarrierRating.Domain.Entities
{
    public class Rating: MongoEntity, IDataTransferObject<RatingDTO>
    {
        [BsonRepresentation(BsonType.String)]
        public EnumRate Rate { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public Carrier Carrier { get; set; }

        public RatingDTO GetDTO()
        {
            return new RatingDTO(this);
        }
    }
}