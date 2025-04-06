using Diploma.Domain.Models;
using Diploma.Domain.Predictions;
using Diploma.Domain.Predictions.Settings;

namespace Diploma.Application.Predictions.Interfaces
{
    /// <summary>
    /// Defines a repository responsible for generating predictions based on a given model file
    /// </summary>
    public interface IPredictionRepository
    {
        /// <summary>
        /// Gets the model type associated with this prediction repository
        /// </summary>
        public ModelType ForModelType { get; }

        /// <summary>
        /// Generates predictions based on the specified settings and model file
        /// </summary>
        /// <param name="predictionSettings">Prediction settings matching the model type</param>
        /// <param name="modelFile">The model file used for predictions</param>
        /// <returns>A list of predictions</returns>
        public List<Prediction> GetPredictions(IPredictionSettings predictionSettings, MemoryStream modelFile);
    }
}
