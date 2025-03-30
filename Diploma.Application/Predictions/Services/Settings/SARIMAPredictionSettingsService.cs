using Diploma.Application.Predictions.Interfaces;
using Diploma.Domain.Common.Helpers;
using Diploma.Domain.Common.Models;
using Diploma.Domain.Models;
using Diploma.Domain.Predictions.Settings;

namespace Diploma.Application.Predictions.Services.Settings
{
    internal class SarimaPredictionSettingsService : IPredictionSettingsService
    {
        public ModelType ForModelType => ModelType.SARIMA;

        public IPredictionSettings GetSettings(Model model, DateTime predictionFrom, DateTime predictionTo)
        {
            if (predictionFrom >= predictionTo)
            {
                throw new ArgumentException("The 'From' date must be earlier than the 'To' date.");
            }

            if (predictionFrom < model.TrainingTime.From || predictionTo < model.TrainingTime.From)
            {
                throw new InvalidOperationException("The requested range is outside the model's training range.");
            }

            var trainingDifference = predictionFrom - model.TrainingTime.From;
            var predictionDifference = predictionTo - predictionFrom;

            var trainingDuration = DateTimeHelper.CalculateDuration(model.TrainingTime.Type, trainingDifference);
            var predictionDuration = DateTimeHelper.CalculateDuration(model.TrainingTime.Type, predictionDifference);

            var inputIndexes = Enumerable
                // Need +1 because of DateTime subtraction returns the number of days excluding the start date.
                .Range((int)trainingDuration, (int)predictionDuration + 1)
                .ToList();

            return new SarimaPredictionSettings(predictionFrom, predictionTo, model.TrainingTime.Type, inputIndexes);
        }
    }
}
