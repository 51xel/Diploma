using Diploma.Domain.Models;
using Diploma.Domain.Predictions.Settings;

namespace Diploma.Application.Predictions.Interfaces
{
    public interface IPredictionSettingsService
    {
        public ModelType ForModelType { get; }
        public IPredictionSettings GetSettings(Model model, DateTime predictionFrom, DateTime predictionTo);
    }
}
