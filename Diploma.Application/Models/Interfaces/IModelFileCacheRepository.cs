namespace Diploma.Application.Models.Interfaces
{
    /// <summary>
    /// Defines a cache repository for storing and retrieving model files
    /// </summary>
    public interface IModelFileCacheRepository
    {
        /// <summary>
        /// Retrieves a model file from the cache
        /// </summary>
        /// <param name="modelId">The unique identifier of the model</param>
        /// <param name="cancellationToken">Token to monitor for cancellation requests</param>
        /// <returns>The cached model file as a MemoryStream, or null if not found</returns>
        public Task<MemoryStream?> GetAsync(Guid modelId, CancellationToken cancellationToken);

        /// <summary>
        /// Stores a model file in the cache
        /// </summary>
        /// <param name="modelId">The unique identifier of the model</param>
        /// <param name="modelFile">The model file to be cached</param>
        /// <param name="cancellationToken">Token to monitor for cancellation requests</param>
        public Task SaveAsync(Guid modelId, MemoryStream modelFile, CancellationToken cancellationToken);
    }
}
