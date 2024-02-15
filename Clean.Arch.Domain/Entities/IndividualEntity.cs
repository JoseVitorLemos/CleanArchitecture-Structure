using Clean.Arch.Domain.Enums;
using Clean.Arch.Helpers.Utils;
using Clean.Arch.Helpers.Validations;

namespace Clean.Arch.Domain.Entities;

public sealed class IndividualEntity : BaseEntity
{
    public string Name { get; private set; }
    public string Cpf { get; private set; }
    public DateTime BirthDate { get; private set; }
    public Genders Gender { get; private set; }

    public IndividualEntity(string name, string cpf, DateTime birthDate, Genders gender)
    {
        Validations(name, cpf, birthDate, gender);

        Name = name;
        Cpf = cpf;
        BirthDate = birthDate;
        Gender = gender;
    }

    private void Validations(string name, string cpf, DateTime birthDate, Genders gender)
    {
        ExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required.");
        ExceptionValidation.When(!CpfValidations.IsValid(cpf), "Cpf is required.");
        ExceptionValidation.When(DateTime.MinValue == birthDate, "BirthDate is required.");
        ExceptionValidation.When(!EnumValidations.IsValidEnum<Genders>(gender), "Gender is required.");
    }
}
