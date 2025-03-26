using FluentValidation.Results;

namespace NLPC_EPS_server.Application.Exceptions
{
    public class BadRequestExceptions : Exception
    {
        public List<string> ValidationErrors { get; set; }
        public BadRequestExceptions(string message) : base(message) { }

        public BadRequestExceptions(string message, ValidationResult validationResult) : base(message)
        {
            ValidationErrors = new();
            foreach (var error in validationResult.Errors)
            {
                ValidationErrors.Add(error.ErrorMessage);
            }
        }
    }
}
