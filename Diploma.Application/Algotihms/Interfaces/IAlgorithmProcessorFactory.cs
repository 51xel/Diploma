using Diploma.Domain.Algorithms;

namespace Diploma.Application.Algotihms.Interfaces
{
    public interface IAlgorithmProcessorFactory
    {
        public IAlgorithmProcessor GetAlgorithmProcessor(AlgorithmType algorithmType);
    }
}
