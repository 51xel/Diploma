using Diploma.Application.Algotihms.Interfaces;
using Diploma.Application.Predictions.Interfaces;
using Diploma.Domain.Actions;
using Diploma.Domain.Algorithms;
using Diploma.Domain.Algorithms.Settings;
using Diploma.Domain.Common.Models;
using Diploma.Domain.TradeActions;

namespace Diploma.Application.Algotihms.Services.AlgorithmProcessors
{
    public class BTCProcessor : IAlgorithmProcessor
    {
        private readonly IExternalPredictionRepository _externalPredictionRepository;

        public BTCProcessor(IExternalPredictionRepository externalPredictionRepository)
        {
            _externalPredictionRepository = externalPredictionRepository;
        }

        public AlgorithmType Type => AlgorithmType.BTC;

        public async Task<TradePair?> ProcessAlgorithmAsync(Algorithm algorithm)
        {
            if (algorithm.Type != AlgorithmType.BTC)
            {
                throw new NotSupportedException($"Algorithm type '{algorithm.Type}' is not supported. Only 'BTC' is allowed.");
            }

            var modelByDays = algorithm.Models.FirstOrDefault(model => model.TrainingTime.Type == TimeRangeType.ByDays);

            if (modelByDays is null)
            {
                throw new InvalidOperationException($"No model found with training time type {TimeRangeType.ByDays}.");
            }

            var predictions = await _externalPredictionRepository.GetPredictionsAsync(
                modelByDays.Id,
                BTCSettings.DaysPredictionFrom,
                BTCSettings.DaysPredictionTo);

            if (predictions.Count() != BTCSettings.DaysToPredict)
            {
                throw new InvalidOperationException($"Expected {BTCSettings.DaysToPredict} predictions, but received {predictions.Count()}.");
            }

            var minPrice = predictions.MinBy(p => p.Price);
            var maxPrice = predictions.MaxBy(p => p.Price);

            if (minPrice is null || maxPrice is null || minPrice.Time >= maxPrice.Time)
            {
                return null;
            }

            var buyAction = new TradeAction(minPrice, TradeActionType.Buy, algorithm);
            var sellAction = new TradeAction(maxPrice, TradeActionType.Sell, algorithm);

            return new TradePair(buyAction, sellAction);
        }
    }
}
