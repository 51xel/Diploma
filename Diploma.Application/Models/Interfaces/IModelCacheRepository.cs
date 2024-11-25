namespace Diploma.Application.Models.Interfaces
{
    public interface IModelCacheRepository
    {
        public bool TryGetModel(Guid id, out MemoryStream? modelData);
        public void CreateModel(Guid id, MemoryStream modelData);
    }
}
