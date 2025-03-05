namespace Diploma.Application.Models.Interfaces
{
    public interface IModelFileCacheRepository
    {
        public Task<MemoryStream?> GetAsync(Guid modelId, CancellationToken cancellationToken);
        public Task SaveAsync(Guid modelId, MemoryStream modelFile, CancellationToken cancellationToken);
    }
}
