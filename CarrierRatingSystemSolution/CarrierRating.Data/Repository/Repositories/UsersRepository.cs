using CarrierRating.Data.DatabaseContext;
using CarrierRating.Data.Repository.Interfaces;
using CarrierRating.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace CarrierRating.Data.Repository.Repositories
{
    public class UsersRepository: IUsersRepository
    {
        protected readonly MongoDBContext _context;
        protected readonly IMongoCollection<BsonDocument> _collection;
        public UsersRepository()
        {
            _context = new MongoDBContext();
            _collection = _context.GetDatabase().GetCollection<BsonDocument>("users");
        }

        public User GetByEmail(string email)
        {
            var filter = new BsonDocument { { "Email", email } };
            var identityUser = _collection.Find(filter).FirstOrDefault();
            if(identityUser != null) {
                var user = BsonSerializer.Deserialize<User>(identityUser["UserInfo"].ToBsonDocument());
                return user;
            }
            return null;
        }
    }
}
