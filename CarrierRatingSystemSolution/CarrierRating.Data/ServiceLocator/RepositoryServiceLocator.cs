using CarrierRating.Data.Base;
using CarrierRating.Data.Repository.Interfaces;
using CarrierRating.Data.Repository.Repositories;
using CarrierRating.Domain.Entities.MongoEntities;
using System;
using System.Collections.Generic;

namespace CarrierRating.Data.ServiceLocator
{
    public class RepositoryServiceLocator : IRepositoryServiceLocator
    {
        private IDictionary<object, object> services;
        public RepositoryServiceLocator()
        {
            services = new Dictionary<object, object>();
            this.services.Add(typeof(IUserRepository), new UserRepository());
            this.services.Add(typeof(ICarrierRepository), new CarrierRepository());
            this.services.Add(typeof(ILoginRepository), new LoginRepository());
            this.services.Add(typeof(IRatingRepository), new RatingRepository());
        }
        public T GetRepositoryService<T>()
        {
            try
            {
                return (T)services[typeof(T)];
            }
            catch (KeyNotFoundException)
            {
                throw new ApplicationException("The service in question is not implemented.");
            }
        }
    }
}
