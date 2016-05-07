using System.Collections.Generic;
using CarrierRating.Domain.Entities;

namespace CarrierRating.Validation.CarriersValidation
{
    public class CarrierValidator: ICarrierValidator
    {
        public void Validate(Carrier entity)
        {
            var validationResults = new List<ValidationResult>();
            if(string.IsNullOrWhiteSpace(entity.FirstName))
                validationResults.Add(new ValidationResult("FirstName", "Firstname is required."));
            if (string.IsNullOrWhiteSpace(entity.LastName))
                validationResults.Add(new ValidationResult("LastName", "Lastname is required."));

            if(validationResults.Count > 0)
                throw new ValidationException(validationResults);
        }
    }
}
