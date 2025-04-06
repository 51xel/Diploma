using Diploma.Domain.Models;
using Diploma.Domain.Predictions.Settings;

namespace Diploma.Application.Predictions.Interfaces
{
    /// <summary>
    /// Provides functionality to generate prediction settings for a given model and date range.
    /// </summary>
    public interface IPredictionSettingsService
    {
        /// <summary>
        /// Gets the model type associated with this service.
        /// </summary>
        public ModelType ForModelType { get; }

        /// <summary>
        /// Creates prediction settings for the specified model and date range.
        /// </summary>
        /// <param name="model">The model for which predictions are made.</param>
        /// <param name="predictionFrom">The start date of the prediction period.</param>
        /// <param name="predictionTo">The end date of the prediction period.</param>
        /// <returns>The generated prediction settings.</returns>
        public IPredictionSettings GetSettings(Model model, DateTime predictionFrom, DateTime predictionTo);
    }
}
