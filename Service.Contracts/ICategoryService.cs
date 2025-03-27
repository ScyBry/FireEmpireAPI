using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;
using System.Collections;

namespace Service.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync(bool trackChanges);

        Task<CategoryDTO> CreateCategoryAsync(CategoryForCreationDTO categoryForCreationDto,
            bool trackChanges);
    }
}