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
        CreateMap<ProjectForCreationDTO, Project>().ForMember(c => c.ImagesPath, opt => opt.Ignore());
        CreateMap<Project, ProjectDTO>();

        CreateMap<ProductForCreationDTO, Product>().ForMember(c => c.ImagesPath, opt => opt.Ignore());
        CreateMap<Product, ProductDTO>();

        CreateMap<FireworkForCreationDTO, Firework>().AfterMap((src, dest)
            =>
        {
            dest.NormalizedName = NormalizeName(src.Name);
        });
    }


    private string NormalizeName(string name) => string.IsNullOrEmpty(name) ? string.Empty : name.ToLower().Replace(" ", string.Empty);
}
