using Microsoft.AspNetCore.Mvc;
using Clean.Arch.Services.DTO;
using Clean.Arch.Services.IndividualEntityService;

namespace Clean.Arch.Presentation.Controllers.IndivudalEntity;

[Route("api/[controller]")]
[ApiController]
public class IndividualEntityController : ControllerBase
{
    private readonly IIndividualEntityService _individualEntityService;

    public IndividualEntityController(IIndividualEntityService individualEntityService)
    {
        _individualEntityService = individualEntityService;
    }

    [HttpGet("ListIndividualEntity")]
    public async Task<List<IndividualEntityDTO>> ListIndividualEntity()
        => await _individualEntityService.ListIndividualEntity();

    [HttpGet("GetIndividualEntity")]
    public async Task<IndividualEntityDTO> GetIndividualEntity(Guid id)
        => await _individualEntityService.GetIndividualEntity(id);

    [HttpPost("InsertIndividualEntity")]
    public async Task InsertIndividualEntity([FromBody] IndividualEntityDTO entity)
        => await _individualEntityService.InsertIndividualEntity(entity);

    [HttpPut("UpdateIndividualEntity")]
    public async Task UpdateIndividualEntity([FromBody] IndividualEntityDTO entity)
        => await _individualEntityService.UpdateIndividualEntity(entity);

    [HttpDelete("RemoveIndividualEntity")]
    public async Task RemoveIndividualEntity(Guid id)
        => await _individualEntityService.RemoveIndividualEntity(id);
}
