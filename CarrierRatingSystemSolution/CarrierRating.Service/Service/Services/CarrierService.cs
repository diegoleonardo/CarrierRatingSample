using CarrierRating.Data.Repository.Interfaces;
using CarrierRating.Data.ServiceLocator;
using CarrierRating.Service.Service.Base;
using CarrierRating.Service.Service.Interfaces;
using CarrierRating.Validation.CarriersValidation;
using CarrierRating.Domain.Entities;

namespace CarrierRating.Service.Service.Services
{
    public class CarrierService: EntityServiceBase<Carrier>, ICarrierService
    {
        private readonly IRepositoryServiceLocator _serviceLocator;
        private readonly ICarrierRepository _carrierRepository;
        private readonly ICarrierValidator _validator;
        public CarrierService()
        {
            _validator = new CarrierValidator();
            _serviceLocator = new RepositoryServiceLocator(); 
            _carrierRepository = _serviceLocator.GetRepositoryService<ICarrierRepository>();
        }

        public override void Create(Carrier entity)
        {
            _validator.Validate(entity);
            base.Create(entity);
        }

        public override void Update(Carrier entity)
        {
            _validator.Validate(entity);
            base.Update(entity);
        }
    }
}
