using Diploma.Application.Algotihms.Interfaces;
using Diploma.Domain.Algorithms;

namespace Diploma.Application.Algotihms.Services
{
    internal class AlgorithmService : IAlgorithmService
    {
        private readonly IAlgorithmRepository _algorithmRepository;

        public AlgorithmService(IAlgorithmRepository algorithmRepository)
        {
            _algorithmRepository = algorithmRepository;
        }

        public async Task<IEnumerable<Algorithm>> GetAvailableAlgorithmsForProcessingAsync()
        {
            var algorithms = await _algorithmRepository.GetAlgorithmsAsync();

            return algorithms.Where(algorithm => algorithm.Models.Count != 0);
        }
    }
}
