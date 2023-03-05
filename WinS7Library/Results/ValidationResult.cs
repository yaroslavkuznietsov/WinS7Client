using System.Collections.Generic;
using System.Linq;

namespace WinS7Library.Results
{
    public class ValidationResult
    {
        public ValidationResult()
        {

        }

        public ValidationResult(IList<ValidationFailure> errors)
        {
            Errors.AddRange(errors);
        }

        public ValidationResult(string error)
            : this(new ValidationFailure { Message = error })
        {
        }

        public ValidationResult(ValidationFailure error)
            : this(new List<ValidationFailure> { error })
        {
        }
        public bool IsValid => Errors.Count == 0;

        public List<ValidationFailure> Errors { get; } = new List<ValidationFailure>();

        public static ValidationResult Succesful => new ValidationResult();

        public ValidationResult Merge(ValidationResult other)
        {
            return new ValidationResult(this.Errors.Concat(other.Errors).ToList());
        }

        public static ValidationResult FromResult(Result result)
        {
            if (result.ValidationResult.IsValid)
            {
                if (result.Successful)
                    return ValidationResult.Succesful;

                return new ValidationResult(result.ErrorMessage);
            }

            return result.ValidationResult;
        }
    }
}
