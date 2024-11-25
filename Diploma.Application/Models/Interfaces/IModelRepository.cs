using Diploma.Domain.Models;

namespace Diploma.Application.Models.Interfaces
{
    public interface IModelRepository
    {
        public Task<Model?> GetModelByIdAsync(Guid id);
    }
}
