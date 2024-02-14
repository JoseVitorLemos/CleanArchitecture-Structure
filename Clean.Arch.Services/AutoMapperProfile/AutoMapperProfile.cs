using AutoMapper;
using Clean.Arch.Domain.Entities;
using Clean.Arch.Services.DTO;

namespace Clean.Arch.Services.AutoMapperProfile;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<IndividualEntity, IndividualEntityDTO>()
            .ForMember(x => x.Gender, opt => opt.ToString()).ReverseMap();
    }
}
