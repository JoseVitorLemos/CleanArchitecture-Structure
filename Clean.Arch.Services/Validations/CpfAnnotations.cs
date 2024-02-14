using System.ComponentModel.DataAnnotations;
using Clean.Arch.Helpers.Validations;

namespace Clean.Arch.Validations;

public class CpfAnnotations : ValidationAttribute
{
    protected override ValidationResult IsValid(object cpf, ValidationContext validationContext)
    {
        if (CpfValidations.IsValid(Convert.ToString(cpf)))
            return ValidationResult.Success;

        return new ValidationResult("Invalid cpf format.");
    }
}
