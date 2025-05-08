using Diploma.Domain.Algorithms;

namespace Diploma.Application.Algotihms.Interfaces
{
    public interface IAlgorithmRepository
    {
        Task<IEnumerable<Algorithm>> GetAlgorithmsAsync();
    }
}
