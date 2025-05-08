using Diploma.Application.Predictions.Interfaces;
using Diploma.Domain.Models;

namespace Diploma.Application.Predictions.Factories
{
    internal class PredictionRepositoryFactory : IPredictionRepositoryFactory
    {
        private readonly IEnumerable<IPredictionRepository> _predictionRepositories;

        public PredictionRepositoryFactory(IEnumerable<IPredictionRepository> predictionRepositories)
        {
            _predictionRepositories = predictionRepositories;
        }

        public IPredictionRepository GetPredictionRepository(ModelType modelType)
        {
            var predictionRepository = _predictionRepositories.FirstOrDefault(service =>
                service.ForModelType == modelType);

            if (predictionRepository is null)
            {
                throw new InvalidOperationException($"Model type {modelType} does not has prediction repository implementation");
            }

            return predictionRepository;
        }
    }
}
