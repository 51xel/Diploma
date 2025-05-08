using Diploma.Domain.Models;

namespace Diploma.Application.Predictions.Interfaces
{
    public interface IPredictionRepositoryFactory
    {
        public IPredictionRepository GetPredictionRepository(ModelType modelType);
    }
}
