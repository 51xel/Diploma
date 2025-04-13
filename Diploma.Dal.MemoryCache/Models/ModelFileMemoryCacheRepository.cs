using Diploma.Application.Models.Interfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace Diploma.Dal.MemoryCache.Models
{
    internal class ModelFileMemoryCacheRepository : IModelFileCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private const string CacheKeyPrefix = "ModelFile_";

        public ModelFileMemoryCacheRepository(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<MemoryStream?> GetAsync(Guid modelId, CancellationToken cancellationToken)
        {
            var key = GetCacheKey(modelId);
            var cachedBytes = await _distributedCache.GetAsync(key, cancellationToken);

            if (cachedBytes is null)
            {
                return null;
            }

            return new MemoryStream(cachedBytes);
        }

        public async Task SaveAsync(Guid modelId, MemoryStream modelFile, CancellationToken cancellationToken)
        {
            if (modelFile is null || !modelFile.CanRead)
            {
                throw new ArgumentException("Model stream cannot be null or empty.");
            }

            var key = GetCacheKey(modelId);

            if (modelFile.Position != 0)
            {
                modelFile.Position = 0;
            }

            var bytes = modelFile.ToArray();
            await _distributedCache.SetAsync(key, bytes, cancellationToken);
        }

        private string GetCacheKey(Guid modelId) => $"{CacheKeyPrefix}{modelId}";
    }
}
