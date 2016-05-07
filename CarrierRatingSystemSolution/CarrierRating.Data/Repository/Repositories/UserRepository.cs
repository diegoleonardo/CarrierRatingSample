using CarrierRating.Data.Base;
using CarrierRating.Data.Repository.Interfaces;
using CarrierRating.Domain.Entities;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CarrierRating.Data.Repository.Repositories
{
    public class UserRepository : EntityRepositoryBase<User>, IUserRepository
    {
        private IUsersRepository _usersRepository;
        public UserRepository()
        {
            _usersRepository = new UsersRepository();
        }
        public override void Create(User pUser)
        {
            _collection.InsertOne(pUser);
        }

        public User GetByEmail(User pUser)
        {
            var filter = new BsonDocument() { { "Email", pUser.Email } };
            var user = _collection.Find(filter).FirstOrDefault();
            return user;
        }

        public bool IsUserOfSystem(User pUser)
        {
            var isUser = false;
            var user = _usersRepository.GetByEmail(pUser.Email);
            if (user != null)
                isUser = true;
            return isUser;
        }
    }
}
