
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CarrierRating.Validation
{
    public class ValidationResult
    {
        public ValidationResult(string key, string message) {
            Key = key;
            Message = message;
        }
        public string Key { get; private set; }
        public string Message { get; private set; }
    }

    public class ValidationException : Exception
    {
        public ValidationException(IEnumerable<ValidationResult> r)
            : base(GetFirstErrorMessage(r))
        {
            this.Errors = new ReadOnlyCollection<ValidationResult>(r.ToArray());
        }

        public ReadOnlyCollection<ValidationResult> Errors { get; private set; }

        private static string GetFirstErrorMessage(
            IEnumerable<ValidationResult> errors)
        {
            return errors.First().Message;
        }
    }
}
