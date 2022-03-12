using AdvertisementApp.Common;
using FluentValidation.Results;

namespace AdvertisementApp.Business.Extensions
{
    public static class ValidationResultExtension
    {
        public static List<CustomValidationError> ConvertToCustomValidationError(this ValidationResult validationResult)
        {
            List<CustomValidationError> errors = new();
            foreach (var error in validationResult.Errors)
            {
                errors.Add(new CustomValidationError()
                {
                    ProperyName = error.PropertyName,
                    ErrorMessage = error.ErrorMessage
                });
            }
            return errors;
        }
    }
}