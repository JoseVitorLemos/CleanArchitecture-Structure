using Clean.Arch.Domain.Entities;

namespace Clean.Arch.Domain.Interfaces;

public interface IIndividualEntity 
{
    Task<List<IndividualEntity>> GetAll();
    Task<IndividualEntity> GetById(int id);
    Task<IndividualEntity> Insert(IndividualEntity entity);
    Task<IndividualEntity> UpdateById(int id);
    Task<List<IndividualEntity>> UpdateAll(List<IndividualEntity> entities);
    Task<IndividualEntity> Delete(int id);
}
