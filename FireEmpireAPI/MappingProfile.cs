using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.Product;
using Shared.DataTransferObjects.Projects;

namespace FireEmpireAPI;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CategoryForCreationDTO, Category>();
        CreateMap<Category, CategoryDTO>();
    }
}