using Diploma.Domain.Models;

namespace Diploma.Application.Predictions.Interfaces
{
    public interface IPredictionSettingsFactory
    {
        public IPredictionSettingsService GetPredictionSettingsService(ModelType modelType);
    }
}
