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
        private readonly IModelRepository _modelsRepository;
        private readonly IModelCacheService _modelsCacheService;
        private readonly IPredictionSettingsFactory _predictionSettingsFactory;
        private readonly IPredictionRepositoryFactory _predictionRepositoryFactory;

        public PredictPriceHandler(
            IModelRepository modelsRepository,
            IModelCacheService modelsCacheService,
            IPredictionSettingsFactory predictionSettingsFactory,
            IPredictionRepositoryFactory predictionRepositoryFactory)
        {
            _validator = new PredictPriceValidator();
            _modelsRepository = modelsRepository;
            _modelsCacheService = modelsCacheService;
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

            var model = await _modelsRepository.GetModelByIdAsync(request.ModelId);

            if (model is null)
            {
                return Error.NotFound($"Model not found by id {request.ModelId}");
            }

            var modelStream = await _modelsCacheService.GetOrCreateModelStreamAsync(model);

            if (modelStream is null)
            {
                return Error.Failure($"Can`t get model data with name {model.Name}");
            }

            var predictionSettingsService = _predictionSettingsFactory.GetPredictionSettingsService(model.Type);
            var predictionSettings = predictionSettingsService.GetSettings(model, request.From, request.To);

            var predictionRepository = _predictionRepositoryFactory.GetPredictionRepository(model.Type);
            var predictions = predictionRepository.GetPredictions(predictionSettings, modelStream);

            return predictions;
        }
    }
}
