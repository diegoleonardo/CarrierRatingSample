using CarrierRating.Domain.Entities.MongoEntities;
using System.Collections.Generic;

namespace CarrierRating.Data.Base
{
    public interface IEntityRepositoryBase<T> where T : IMongoEntity
    {
        void Create(T entity);

        void Delete(string id);

        T GetById(string id);

        IList<T> GetAll();

        void Update(T entity);
    }
}
