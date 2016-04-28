using System.Collections.Generic;
using CarrierRating.Data.Base;
using CarrierRating.Data.Repository.Interfaces;
using CarrierRating.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarrierRating.Data.Repository.Repositories
{
    public class RatingRepository : EntityRepositoryBase<Rating>, IRatingRepository
    {
        public IList<Rating> GetByCarrierId(string carrierId)
        {
            return _collection.Find(x=>x.Carrier.Id.Equals(new ObjectId(carrierId))).ToList();
        }

        public Rating GetByUserId(string userId)
        {
            var filter = new BsonDocument { { "User._id", userId } };
            return _collection.Find(filter).FirstOrDefault();
        }
    }
}
