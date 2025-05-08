using Diploma.Domain.Algorithms;

namespace Diploma.Application.Algotihms.Interfaces
{
    public interface IAlgorithmService
    {
        Task<IEnumerable<Algorithm>> GetAvailableAlgorithmsForProcessingAsync();
    }
}
