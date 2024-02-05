using Clean.Arch.Domain.Enums;
using Clean.Arch.Domain.Validations;

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
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required.");
        DomainExceptionValidation.When(string.IsNullOrEmpty(cpf), "Cpf is required.");
        DomainExceptionValidation.When(DateTime.MinValue == birthDate, "BirthDate is required.");
        DomainExceptionValidation.When(gender == Genders.Undefined, "Gender is required.");
    }
}
