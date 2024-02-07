using Clean.Arch.Domain.Entities;
using FluentAssertions;
using Clean.Arch.Domain.Enums;

namespace Clean.Arch.Tests;

public class IndividualEntityTest
{
    private readonly IndividualEntity mockIndivualEntity;

    public IndividualEntityTest()
    {
        mockIndivualEntity = MockIndivualEntity();
    }

    private IndividualEntity MockIndivualEntity()
    {
        var person = new IndividualEntity("Any Name", "613.261.260-24", DateTime.UtcNow, Genders.Male);
        return person; 
    }

    [Fact]
    public void CreatePerson_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new IndividualEntity(mockIndivualEntity.Name, mockIndivualEntity.Cpf, mockIndivualEntity.BirthDate, mockIndivualEntity.Gender);
        action.Should()
              .NotThrow<Clean.Arch.Domain.Validations.DomainExceptionValidation>();
    } 

    [Fact]
    public void CreatePerson_WithInvalidValidParameters_InvalidName()
    {
        Action action = () => new IndividualEntity(string.Empty, mockIndivualEntity.Cpf, mockIndivualEntity.BirthDate, mockIndivualEntity.Gender);
        action.Should().ThrowExactly<Clean.Arch.Domain.Validations.DomainExceptionValidation>()
              .WithMessage("Name is required.");
    } 

    [Fact]
    public void CreatePerson_WithInvalidValidParameters_InvalidCpf()
    {
        Action action = () => new IndividualEntity(mockIndivualEntity.Name, string.Empty, mockIndivualEntity.BirthDate, mockIndivualEntity.Gender);
        action.Should().ThrowExactly<Clean.Arch.Domain.Validations.DomainExceptionValidation>()
              .WithMessage("Cpf is required.");
    } 

    [Fact]
    public void CreatePerson_WithInvalidValidParameters_InvalidBirthDate()
    {
        Action action = () => new IndividualEntity(mockIndivualEntity.Name, mockIndivualEntity.Cpf, DateTime.MinValue, mockIndivualEntity.Gender);
        action.Should().ThrowExactly<Clean.Arch.Domain.Validations.DomainExceptionValidation>()
              .WithMessage("BirthDate is required.");
    } 

    [Fact]
    public void CreatePerson_WithInvalidValidParameters_InvalidGender()
    {
        Action action = () => new IndividualEntity(mockIndivualEntity.Name, mockIndivualEntity.Cpf, mockIndivualEntity.BirthDate, Genders.Undefined);
        action.Should().ThrowExactly<Clean.Arch.Domain.Validations.DomainExceptionValidation>()
              .WithMessage("Gender is required.");
    } 
}
