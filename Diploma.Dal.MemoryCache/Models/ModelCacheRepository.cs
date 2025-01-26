using Diploma.Application.Models.Interfaces;

namespace Diploma.Dal.MemoryCache.Models
{
    internal class ModelCacheRepository : IModelCacheRepository
    {
        private readonly Dictionary<Guid, MemoryStream> cachedModels = new Dictionary<Guid, MemoryStream>();

        public void SaveModelAsync(Guid id, MemoryStream modelStream)
        {
            cachedModels.Add(id, modelStream);
        }

        public bool TryGetModelAsync(Guid id, out MemoryStream? modelStream)
        {
            return cachedModels.TryGetValue(id, out modelStream);
        }
    }
}
