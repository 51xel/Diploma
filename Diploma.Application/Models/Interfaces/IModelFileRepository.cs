namespace Diploma.Application.Models.Interfaces
{
    /// <summary>
    /// Defines a repository for retrieving model files from persistent storage
    /// </summary>
    public interface IModelFileRepository
    {
        /// <summary>
        /// Retrieves a model file from storage
        /// </summary>
        /// <param name="modelName">The name of the model, can be file name</param>
        /// <param name="cancellationToken">Token to monitor for cancellation requests</param>
        /// <returns>The model file as a MemoryStream, or null if not found</returns>
        public Task<MemoryStream?> GetAsync(string modelName, CancellationToken cancellationToken);
    }

}
