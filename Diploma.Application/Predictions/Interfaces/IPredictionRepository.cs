using Diploma.Domain.Models;
using Diploma.Domain.Predictions;
using Diploma.Domain.Predictions.Settings;

namespace Diploma.Application.Predictions.Interfaces
{
    public interface IPredictionRepository
    {
        public ModelType ForModelType { get; }
        public List<Prediction> GetPredictions(IPredictionSettings predictionSettings, MemoryStream modelStream);
    }
}
