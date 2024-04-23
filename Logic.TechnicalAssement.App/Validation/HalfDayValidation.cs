using Logic.TechnicalAssement.App.Models;
using System.ComponentModel.DataAnnotations;

namespace Logic.TechnicalAssement.App.Validation
{
    public class HalfDayValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = validationContext.ObjectInstance as LeaveViewModel;

            if (model == null)
            {
                return new ValidationResult("Invalid object type");
            }

            if (model.IsHalfDay && model.StartDate?.Date != model.EndDate?.Date)
            {
                return new ValidationResult("For half day leave, start and end dates must be the same.");
            }

            return ValidationResult.Success;
        }

    }
}
