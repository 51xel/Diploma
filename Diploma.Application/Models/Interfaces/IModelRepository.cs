using Diploma.Domain.Models;

namespace Diploma.Application.Models.Interfaces
{
    /// <summary>
    /// Provides access to model entities.
    /// </summary>
    public interface IModelRepository
    {
        /// <summary>
        /// Retrieves a model entity by its unique identifier
        /// </summary>
        /// <param name="modelId">The unique identifier of the model</param>
        /// <param name="cancellationToken">Token to monitor for cancellation requests</param>
        /// <returns>The model entity, or null if not found</returns>
        public Task<Model?> GetAsync(Guid modelId, CancellationToken cancellationToken);
    }
}
