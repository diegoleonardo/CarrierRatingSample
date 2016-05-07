using CarrierRating.Domain.Entities;
using CarrierRating.Validation.Validator;

namespace CarrierRating.Validation.RatingValidation
{
    public interface IRatingValidator: IValidator<Rating>
    {
    }
}
