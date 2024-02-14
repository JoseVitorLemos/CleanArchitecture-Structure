using Clean.Arch.Services.DTO;

namespace Clean.Arch.Services.IndividualEntityService;

public interface IIndividualEntityService
{
    Task<List<IndividualEntityDTO>> ListIndividualEntity();
    Task<IndividualEntityDTO> GetIndividualEntity(Guid id);
    Task InsertIndividualEntity(IndividualEntityDTO entity);
    Task UpdateIndividualEntity(IndividualEntityDTO entity);
    Task RemoveIndividualEntity(Guid id);
}
