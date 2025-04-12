using Diploma.Application.Models.Interfaces;
using Diploma.Dal.RedisCache.Common.Settings;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Diploma.Dal.RedisCache.Models
{
    internal class ModelFileRedisCacheRepository : IModelFileCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly RedisCacheSettings _redisCacheSettings;

        public ModelFileRedisCacheRepository(
            IDistributedCache distributedCache, 
            IOptions<RedisCacheSettings> redisCacheSettings)
        {
            _distributedCache = distributedCache;
            _redisCacheSettings = redisCacheSettings.Value;
        }

        public async Task SaveAsync(Guid modelId, MemoryStream modelFile, CancellationToken cancellationToken)
        {
            if (modelFile is null || !modelFile.CanRead)
            {
                throw new ArgumentException("Model stream cannot be null or empty.");
            }

            var modelBytes = modelFile.ToArray();

            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = _redisCacheSettings.ExpirationTime
            };

            await _distributedCache.SetAsync(modelId.ToString(), modelBytes, cacheOptions, cancellationToken);
        }

        public async Task<MemoryStream?> GetAsync(Guid modelId, CancellationToken cancellationToken)
        {
            var modelBytes = await _distributedCache.GetAsync(modelId.ToString(), cancellationToken);

            if (modelBytes is null) 
            {
                return null;
            }

            return new MemoryStream(modelBytes);
        }
    }
}
