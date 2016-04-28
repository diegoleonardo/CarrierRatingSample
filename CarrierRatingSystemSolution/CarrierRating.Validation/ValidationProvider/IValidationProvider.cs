using System.Collections;

namespace CarrierRating.Validation.ValidationProvider
{
    public interface IValidationProvider
    {
        void Validate(object entity);
        void ValidateAll(IEnumerable entities);
    }
}
