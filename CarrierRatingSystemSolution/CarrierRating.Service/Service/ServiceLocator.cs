using CarrierRating.Service.Service.Interfaces;
using CarrierRating.Service.Service.Services;
using System;
using System.Collections.Generic;

namespace CarrierRating.Service
{
    public class ServiceLocator : IServiceLocator
    {
        private IDictionary<object, object> services;
        public ServiceLocator()
        {
            services = new Dictionary<object, object>();
            this.services.Add(typeof(IUserService), new UserService());
            this.services.Add(typeof(ICarrierService), new CarrierService());
            this.services.Add(typeof(IRatingService), new RatingService());
        }
        public T GetService<T>()
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
