using Microsoft.AspNetCore.Http;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IFireworksService
    {

        public Task<FireworkDTO> CreateFirework(FireworkForCreationDTO firework, bool trackChanges);
        public Task DeleteFirework(Guid id);
        public Task<IEnumerable<FireworkDTO>> ImportFireworksFromExcelAsync(IFormFile file);
        public Task<byte[]> ExportFireworksToExcelAsync();

    };
}
