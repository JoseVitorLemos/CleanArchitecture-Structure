using System.ComponentModel.DataAnnotations;
using Clean.Arch.Domain.Enums;

namespace Clean.Arch.Validations;

public class EnumAnnotations : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        Enum.TryParse(Convert.ToString(value), true, out Genders gender);

        if (gender.Equals(Genders.Undefined))
            return new ValidationResult("gender is Undefined");

        return ValidationResult.Success;
    }
}
