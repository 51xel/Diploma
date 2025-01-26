using Diploma.Domain.Models;

namespace Diploma.Application.Models.Interfaces
{
    public interface IModelFileCacheService
    {
        public Task<MemoryStream?> GetOrAddAsync(Model model);
    }
}
