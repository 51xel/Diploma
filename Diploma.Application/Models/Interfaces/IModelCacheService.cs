using Diploma.Domain.Models;

namespace Diploma.Application.Models.Interfaces
{
    public interface IModelCacheService
    {
        public Task<MemoryStream?> GetOrCreateModelStreamAsync(Model model);
    }
}
