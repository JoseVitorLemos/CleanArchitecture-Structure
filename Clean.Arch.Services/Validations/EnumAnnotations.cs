using System.ComponentModel.DataAnnotations;
using Clean.Arch.Domain.Enums;
using Clean.Arch.Helpers.Utils;

namespace Clean.Arch.Validations;

public class EnumAnnotations : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (EnumValidations.IsValidEnum<Genders>(value))
            return ValidationResult.Success;

        return new ValidationResult("gender is Undefined");
    }
}
