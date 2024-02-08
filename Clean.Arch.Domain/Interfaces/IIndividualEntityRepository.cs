using Clean.Arch.Domain.Entities;

namespace Clean.Arch.Domain.Interfaces;

public interface IIndividualEntityRepository 
{
    Task<List<IndividualEntity>> GetAll();
    Task<IndividualEntity> GetById(int id);
    Task<IndividualEntity> Insert(IndividualEntity entity);
    Task<IndividualEntity> Update(IndividualEntity entity);
    Task<List<IndividualEntity>> UpdateAll(List<IndividualEntity> entities);
    Task<IndividualEntity> Delete(IndividualEntity entity);
    Task<List<IndividualEntity>> DeleteAll(List<IndividualEntity> entities);
}
