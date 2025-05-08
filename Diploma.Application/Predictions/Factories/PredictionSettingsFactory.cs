using Diploma.Application.Predictions.Interfaces;
using Diploma.Domain.Models;

namespace Diploma.Application.Predictions.Factories
{
    internal class PredictionSettingsFactory : IPredictionSettingsFactory
    {
        private readonly IEnumerable<IPredictionSettingsService> _predictionSettingsServices;

        public PredictionSettingsFactory(IEnumerable<IPredictionSettingsService> predictionSettingsServices)
        {
            _predictionSettingsServices = predictionSettingsServices;
        }

        public IPredictionSettingsService GetPredictionSettingsService(ModelType modelType)
        {
            var predictionSettingsService = _predictionSettingsServices.FirstOrDefault(service =>
                service.ForModelType == modelType);

            if (predictionSettingsService is null)
            {
                throw new InvalidOperationException($"Model type {modelType} does not has prediction settings service implementation");
            }

            return predictionSettingsService;
        }
    }
}
