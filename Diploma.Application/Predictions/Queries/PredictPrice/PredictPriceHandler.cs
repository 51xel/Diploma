using Diploma.Application.Models.Interfaces;
using Diploma.Application.Predictions.Factories.Interfaces;
using Diploma.Domain.Predictions;
using ErrorOr;
using MediatR;

namespace Diploma.Application.Predictions.Queries.PredictPrice
{
    internal class PredictPriceHandler : IRequestHandler<PredictPriceQuery, ErrorOr<IEnumerable<Prediction>>>
    {
        private readonly PredictPriceValidator _validator;
        private readonly IModelRepository _modelRepository;
        private readonly IModelFileCacheService _modelFileCacheService;
        private readonly IPredictionSettingsFactory _predictionSettingsFactory;
        private readonly IPredictionRepositoryFactory _predictionRepositoryFactory;

        public PredictPriceHandler(
            IModelRepository modelsRepository,
            IModelFileCacheService modelsCacheService,
            IPredictionSettingsFactory predictionSettingsFactory,
            IPredictionRepositoryFactory predictionRepositoryFactory)
        {
            _validator = new PredictPriceValidator();
            _modelRepository = modelsRepository;
            _modelFileCacheService = modelsCacheService;
            _predictionSettingsFactory = predictionSettingsFactory;
            _predictionRepositoryFactory = predictionRepositoryFactory;
        }

        public async Task<ErrorOr<IEnumerable<Prediction>>> Handle(
            PredictPriceQuery request,
            CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return validationResult.Errors
                    .Select(error => Error.Validation(error.PropertyName, error.ErrorMessage))
                    .ToList();
            }

            var model = await _modelRepository.GetAsync(request.ModelId);

            if (model is null)
            {
                return Error.NotFound(description: $"Model not found by id {request.ModelId}");
            }

            using (var modelFile = await _modelFileCacheService.GetOrAddAsync(model))
            {
                if (modelFile is null)
                {
                    return Error.Failure(description: $"Can`t get model data with name {model.Name}");
                }

                var predictionSettings = _predictionSettingsFactory
                    .GetPredictionSettingsService(model.Type)
                    .GetSettings(model, request.From, request.To);

                var predictions = _predictionRepositoryFactory
                    .GetPredictionRepository(model.Type)
                    .GetPredictions(predictionSettings, modelFile);

                return predictions;
            }
        }
    }
}
