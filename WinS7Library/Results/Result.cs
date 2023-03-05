using System;

namespace WinS7Library.Results
{
    public class Result
    {
        public bool Successful { get; set; }
        public object Parameter { get; set; }
        public string ErrorMessage { get; set; }
        public ValidationResult ValidationResult { get; set; } = new ValidationResult();

        public static Result Error(string message)
        {
            return new Result
            {
                ErrorMessage = message,
                Successful = false
            };
        }

        public static Result Success
        {
            get
            {
                return new Result
                {
                    ErrorMessage = string.Empty,
                    Successful = true
                };
            }
        }

        public Result AggregateWith(Result otheResult)
        {
            return Aggregate(this, otheResult);
        }

        public static Result Aggregate(Result x, Result y)
        {
            if (x.Successful && y.Successful)
                return Success;

            if (x.Successful && !y.Successful)
                return y;

            if (!x.Successful && y.Successful)
                return x;

            return Error(x.ErrorMessage + Environment.NewLine + y.ErrorMessage);
        }

        public static Result SuccessWithParameter(object parameter)
        {
            return new Result
            {
                ErrorMessage = string.Empty,
                Successful = true,
                Parameter = parameter
            };
        }

        public static Result ErrorWithParameter(object parameter, string errorMessage)
        {
            return new Result
            {
                ErrorMessage = errorMessage,
                Successful = false,
                Parameter = parameter
            };
        }

        public static Result WithValidationError(ValidationResult validationResult)
        {
            return new Result
            {
                ErrorMessage = "Validation failed",
                Successful = false,
                ValidationResult = validationResult
            };
        }
        public override string ToString()
        {
            return
                $"{nameof(Successful)}: {Successful}{(Successful ? null : $", {nameof(ErrorMessage)}: {ErrorMessage}")}";
        }
    }
}
