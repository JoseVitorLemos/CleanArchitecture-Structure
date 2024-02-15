using Clean.Arch.Domain.Entities;
using Clean.Arch.Domain.Interfaces;

namespace Clean.Arch.Business.IndividualEntityBusiness;

public class IndividualEntityBusiness : IIndividualEntityBusiness
{
    private readonly IRepository<IndividualEntity> _individualEntityRepository;

    public IndividualEntityBusiness(IRepository<IndividualEntity> individualEntityRepository)
    {
        _individualEntityRepository = individualEntityRepository;
    }

    public async Task<IndividualEntity> GetIndividualEntity(Guid id)
        => await _individualEntityRepository.GetById(id);

    public async Task InsertIndividualEntity(IndividualEntity entity)
        => await _individualEntityRepository.Insert(entity);

    public async Task<List<IndividualEntity>> ListIndividualEntity()
        => await _individualEntityRepository.GetAll();

    public async Task RemoveIndividualEntity(Guid id)
        => await _individualEntityRepository.Delete(id);

    public async Task UpdateIndividualEntity(IndividualEntity entity)
        => await _individualEntityRepository.Update(entity);
}
