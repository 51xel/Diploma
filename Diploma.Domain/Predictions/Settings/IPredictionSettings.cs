using Diploma.Domain.Common.Models;

namespace Diploma.Domain.Predictions.Settings
{
    public interface IPredictionSettings 
    {
        public DateTime From { get; init; }
        public DateTime To { get; init; }
        public TimeRangeType TimeRangeType { get; init; }
    }
}
