using FluentAssertions;
using Clean.Arch.Domain.Entities;
using Clean.Arch.Domain.Enums;
using Clean.Arch.Helpers.Validations;

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
              .NotThrow<ExceptionValidation>();
    } 

    [Fact]
    public void CreatePerson_WithInvalidValidParameters_InvalidName()
    {
        Action action = () => new IndividualEntity(string.Empty, mockIndivualEntity.Cpf, mockIndivualEntity.BirthDate, mockIndivualEntity.Gender);
        action.Should().ThrowExactly<ExceptionValidation>()
              .WithMessage("Name is required.");
    } 

    [Fact]
    public void CreatePerson_WithInvalidValidParameters_InvalidCpf()
    {
        Action action = () => new IndividualEntity(mockIndivualEntity.Name, "123456789", mockIndivualEntity.BirthDate, mockIndivualEntity.Gender);
        action.Should().ThrowExactly<ExceptionValidation>()
              .WithMessage("Cpf is required.");
    } 

    [Fact]
    public void CreatePerson_WithInvalidValidParameters_InvalidBirthDate()
    {
        Action action = () => new IndividualEntity(mockIndivualEntity.Name, mockIndivualEntity.Cpf, DateTime.MinValue, mockIndivualEntity.Gender);
        action.Should().ThrowExactly<ExceptionValidation>()
              .WithMessage("BirthDate is required.");
    } 

    [Fact]
    public void CreatePerson_WithInvalidValidParameters_InvalidGender()
    {
        Action action = () => new IndividualEntity(mockIndivualEntity.Name, mockIndivualEntity.Cpf, mockIndivualEntity.BirthDate, Genders.Undefined);
        action.Should().ThrowExactly<ExceptionValidation>()
              .WithMessage("Gender is required.");
    } 
}
