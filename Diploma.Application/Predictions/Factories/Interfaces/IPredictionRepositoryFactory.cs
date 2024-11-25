using Diploma.Application.Predictions.Interfaces;
using Diploma.Domain.Models;

namespace Diploma.Application.Predictions.Factories.Interfaces
{
    public interface IPredictionRepositoryFactory
    {
        public IPredictionRepository GetPredictionRepository(ModelType modelType);
    }
}
