using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace FireEmpireAPI;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ContactEntity, ContactDto>();
        CreateMap<ContactForCreationDto, ContactEntity>();
        CreateMap<ContactForUpdateDto, ContactEntity>();



    }
}