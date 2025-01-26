namespace Diploma.Application.Models.Interfaces
{
    public interface IModelFileCacheRepository
    {
        public Task<MemoryStream?> GetAsync(Guid modelId);
        public Task SaveAsync(Guid modelId, MemoryStream modelFile);
    }
}
