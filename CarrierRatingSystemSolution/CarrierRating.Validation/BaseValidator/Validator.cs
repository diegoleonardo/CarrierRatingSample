using CarrierRating.Validation.Validator;
using System;
using System.Collections.Generic;
namespace CarrierRating.Validation
{
    public abstract class Validator<T> : IValidator<T> where T : class
    {
        public void Validate(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
        }
    }
}
