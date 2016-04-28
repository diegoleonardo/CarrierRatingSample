using CarrierRating.Domain.Entities;
using CarrierRating.Service.Service.Base;
using CarrierRating.Service.Service.Interfaces;
using CarrierRating.Validation.RatingValidation;
using System.Collections.Generic;
using System.Linq;

namespace CarrierRating.Service.Service.Services
{
    public class RatingService: EntityServiceBase<Rating>, IRatingService
    {
        private readonly ICarrierService _carrierService;
        private readonly IRatingValidator _ratingValidator;
        public RatingService()
        {
            _carrierService = new CarrierService();
            _ratingValidator = new RatingValidator();
        }

        public override void Create(Rating entity)
        {
            _ratingValidator.Validate(entity);
            _repositoryBase.Create(entity);
        }

        public IList<Carrier> GetCarrierToRating(string userId)
        {
            var carrierList = _carrierService.GetAll();
            var ratingList = _repositoryBase.GetAll().Where(x => x.User.GetStringId().Equals(userId));
            return carrierList;
        }

        public Carrier GetCarrierById(string carrierId)
        {
            return _carrierService.GetById(carrierId);
        }

        public IList<Rating> GetRatingByUserId(string userId)
        {
            return _repositoryBase.GetAll().Where(x=>x.User.GetStringId().Equals(userId)).ToList();
        }
    }
}
