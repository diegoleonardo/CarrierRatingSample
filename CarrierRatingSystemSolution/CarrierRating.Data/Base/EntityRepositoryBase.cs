using CarrierRating.Data.DatabaseContext;
using CarrierRating.Domain.Entities.MongoEntities;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;

namespace CarrierRating.Data.Base
{
    public class EntityRepositoryBase<T>: IEntityRepositoryBase<T> where T : IMongoEntity
    {
        protected readonly MongoDBContext _context;
        protected readonly IMongoCollection<T> _collection; 
        public EntityRepositoryBase()
        {
            _context = new MongoDBContext();
            _collection = _context.GetDatabase().GetCollection<T>(typeof(T).Name);
        }

        public virtual void Create(T entity)
        {
            _collection.InsertOne(entity);    
        }

        public virtual void Delete(string id)
        {
            var entity = GetById(id);
            var filter = new BsonDocument() { { "_id", entity.Id } };
            _collection.DeleteOne(filter);
        }

        public virtual T GetById(string id)
        {
            ObjectId objectId = new ObjectId(id);
            var filter = new BsonDocument() { { "_id", objectId } };
            return _collection.Find(filter).First();
        }

        public virtual IList<T> GetAll()
        {
            return _collection.Find(Builders<T>.Filter.Empty).ToList();
        }

        public virtual void Update(T entity)
        {
            var filter = Builders<T>.Filter.Eq("_id", entity.Id);
            _collection.ReplaceOne(filter, entity, options: new UpdateOptions { IsUpsert = true });
        }
    }
}
