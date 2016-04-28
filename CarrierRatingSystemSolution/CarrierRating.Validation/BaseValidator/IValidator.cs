using System.Collections.Generic;

namespace CarrierRating.Validation.Validator
{
    public interface IValidator<T>where T: class
    {
        void Validate(T entity);
    }
}
