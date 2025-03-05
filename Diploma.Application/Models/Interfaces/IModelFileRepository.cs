namespace Diploma.Application.Models.Interfaces
{
    public interface IModelFileRepository
    {
        public Task<MemoryStream?> GetAsync(string modelName, CancellationToken cancellationToken);
    }
}
