using CarrierRating.Data.Base;
using CarrierRating.Domain.Entities.MongoEntities;
using System.Collections.Generic;

namespace CarrierRating.Service.Service.Base
{
    public class EntityServiceBase<T>: IEntityServiceBase<T> where T : IMongoEntity
    {
        protected readonly IEntityRepositoryBase<T> _repositoryBase;
        public EntityServiceBase()
        {
            _repositoryBase = new EntityRepositoryBase<T>();
        }

        public virtual void Create(T entity)
        {
            _repositoryBase.Create(entity);
        }

        public virtual void Delete(string id)
        {
            _repositoryBase.Delete(id);
        }

        public virtual T GetById(string id)
        {
            return _repositoryBase.GetById(id);
        }

        public virtual IList<T> GetAll()
        {
            return _repositoryBase.GetAll();
        }

        public virtual void Update(T entity)
        {
            _repositoryBase.Update(entity);
        }
    }
}
