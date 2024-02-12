using System.ComponentModel.DataAnnotations;
using Clean.Arch.Helpers.Validations;

namespace Clean.Arch.Services.DTO;

public class CpfAnnotation : ValidationAttribute
{
    protected override ValidationResult IsValid(object cpf, ValidationContext validationContext)
    {
        if (CpfValidations.IsValid(Convert.ToString(cpf)))
            return ValidationResult.Success;

        return new ValidationResult("Invalid cpf format.");
    }
}
