using Diploma.Application.Predictions.Interfaces;
using Diploma.Domain.Models;

namespace Diploma.Application.Predictions.Factories.Interfaces
{
    public interface IPredictionSettingsFactory
    {
        public IPredictionSettingsService GetPredictionSettingsService(ModelType modelType);
    }
}
