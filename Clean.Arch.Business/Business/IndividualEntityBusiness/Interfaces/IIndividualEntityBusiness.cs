using Clean.Arch.Domain.Entities;

namespace Clean.Arch.Business.IndividualEntityBusiness;

public interface IIndividualEntityBusiness
{
    Task<List<IndividualEntity>> ListIndividualEntity();
    Task<IndividualEntity> GetIndividualEntity(Guid id);
    Task InsertIndividualEntity(IndividualEntity entity);
    Task UpdateIndividualEntity(IndividualEntity entity);
    Task RemoveIndividualEntity(Guid id);
}
