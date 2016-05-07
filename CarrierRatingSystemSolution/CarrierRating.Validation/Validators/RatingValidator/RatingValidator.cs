using CarrierRating.Data.Repository.Interfaces;
using CarrierRating.Data.ServiceLocator;
using CarrierRating.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CarrierRating.Validation.RatingValidation
{
    public class RatingValidator : IRatingValidator
    {
        private IRatingRepository _ratingRepository;
        public RatingValidator()
        {
            var repositoryServiceLocator = new RepositoryServiceLocator();
            _ratingRepository = repositoryServiceLocator.GetRepositoryService<IRatingRepository>();
        }

        public void Validate(Rating entity)
        {
            var validationResults = new List<ValidationResult>();
            if (entity.Carrier == null)
                validationResults.Add(new ValidationResult("Carrier is null", "Carrier is required"));
            if(entity.User == null)
                validationResults.Add(new ValidationResult("User is null", "User is required"));
            if (isCarrierRatedByUser(entity))
                validationResults.Add(new ValidationResult("User already made ​​previously rate", 
                                                            "User already rated this carrier"));
            if(validationResults.Count > 0)
                throw new ValidationException(validationResults);
        }

        private bool isCarrierRatedByUser(Rating entity)
        {
            var ratingsByCarrierId = _ratingRepository.GetByCarrierId(entity.Carrier.GetStringId());
            return ratingsByCarrierId.Any(x => x.User.GetStringId().Equals(entity.User.GetStringId()));
        }
    }
}
