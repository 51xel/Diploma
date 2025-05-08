using Diploma.Domain.Predictions;

namespace Diploma.Application.Predictions.Interfaces
{
    public interface IExternalPredictionRepository
    {
        Task<IEnumerable<Prediction>> GetPredictionsAsync(Guid modelId, DateTime from, DateTime to);
    }
}
