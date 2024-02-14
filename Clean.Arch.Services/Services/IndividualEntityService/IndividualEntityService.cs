using AutoMapper;
using Clean.Arch.Business.IndividualEntityBusiness;
using Clean.Arch.Domain.Entities;
using Clean.Arch.Services.DTO;

namespace Clean.Arch.Services.IndividualEntityService;

public class IndividualEntityService : IIndividualEntityService
{
    private readonly IIndividualEntityBusiness _individualEntityBusiness;
    private readonly IMapper _mapper;

    public IndividualEntityService(IIndividualEntityBusiness individualEntityBusiness, IMapper mapper)
    {
        _individualEntityBusiness = individualEntityBusiness;
        _mapper = mapper;
    }
    public async Task<List<IndividualEntityDTO>> ListIndividualEntity()
        => _mapper.Map<List<IndividualEntityDTO>>(await _individualEntityBusiness.ListIndividualEntity());

    public async Task<IndividualEntityDTO> GetIndividualEntity(Guid id)
        => _mapper.Map<IndividualEntityDTO>(await _individualEntityBusiness.GetIndividualEntity(id));

    public async Task InsertIndividualEntity(IndividualEntityDTO entity)
        => await _individualEntityBusiness.InsertIndividualEntity(_mapper.Map<IndividualEntity>(entity));

    public async Task UpdateIndividualEntity(IndividualEntityDTO entity)
        => await _individualEntityBusiness.UpdateIndividualEntity(_mapper.Map<IndividualEntity>(entity));

    public async Task RemoveIndividualEntity(Guid id)
        => await _individualEntityBusiness.RemoveIndividualEntity(id);
}
