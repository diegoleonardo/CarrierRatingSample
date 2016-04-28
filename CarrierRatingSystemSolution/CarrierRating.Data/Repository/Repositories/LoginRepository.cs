using CarrierRating.Data.Base;
using CarrierRating.Data.Repository.Interfaces;
using CarrierRating.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarrierRating.Data.Repository.Repositories
{
    public class LoginRepository : EntityRepositoryBase<Login>, ILoginRepository
    {
        public override void Create(Login pLogin)
        {
            pLogin.GenerateToken(pLogin.Email, pLogin.Password);
            base.Create(pLogin);
        }
        public bool HasLogin(Login pLogin)
        {
            var filter = new BsonDocument() { { "_id", pLogin.Id } };
            return _collection.Find(filter).Any(); 
        }
    }
}
