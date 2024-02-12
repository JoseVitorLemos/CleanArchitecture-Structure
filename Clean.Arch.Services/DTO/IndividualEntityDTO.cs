using System.ComponentModel.DataAnnotations;
using Clean.Arch.Domain.Enums;

namespace Clean.Arch.Services.DTO;

public class IndividualEntityDTO
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; private set; }
    public string Cpf { get; private set; }
    public DateTime BirthDate { get; private set; }
    public Genders Gender { get; private set; }
}
