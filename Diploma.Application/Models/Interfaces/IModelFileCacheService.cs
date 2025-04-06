using Diploma.Domain.Models;

namespace Diploma.Application.Models.Interfaces
{
    /// <summary>
    /// Provides a caching mechanism for model files, ensuring retrieval or storage when necessary.
    /// </summary>
    public interface IModelFileCacheService
    {
        /// <summary>
        /// Retrieves a model file from the cache or stores it if not already present.
        /// </summary>
        /// <param name="model">The model entity to retrieve or store.</param>
        /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
        /// <returns>The model file as a MemoryStream, or null if not found.</returns>
        public Task<MemoryStream?> GetOrAddAsync(Model model, CancellationToken cancellationToken);
    }

}
