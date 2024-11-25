namespace Diploma.Application.Models.Interfaces
{
    public interface IModelFileRepository
    {
        public Task<MemoryStream?> GetModelAsync(string name);
    }
}
