using Diploma.Application.Algotihms.Interfaces;
using Diploma.Domain.Algorithms;
using Diploma.Domain.Models;

namespace Diploma.Application.Algotihms.Factories
{
    class AlgorithmProcessorFactory : IAlgorithmProcessorFactory
    {
        private readonly IEnumerable<IAlgorithmProcessor> _algorithmProcessors;

        public AlgorithmProcessorFactory(IEnumerable<IAlgorithmProcessor> algorithmProcessors)
        {
            _algorithmProcessors = algorithmProcessors;
        }

        public IAlgorithmProcessor GetAlgorithmProcessor(AlgorithmType algorithmType)
        {
            var algorithmProcessor = _algorithmProcessors.FirstOrDefault(algorithmProcessor => algorithmProcessor.Type == algorithmType);

            if (algorithmProcessor is null)
            {
                throw new InvalidOperationException();
            }

            return algorithmProcessor;
        }
    }
}
