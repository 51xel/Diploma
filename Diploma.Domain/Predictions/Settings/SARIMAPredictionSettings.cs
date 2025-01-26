using Diploma.Domain.Common.Models;

namespace Diploma.Domain.Predictions.Settings
{
    public class SARIMAPredictionSettings : IPredictionSettings
    {
        public DateTime From { get; init; }
        public DateTime To { get; init; }
        public TimeRangeType TimeRangeType { get; init; }

        public List<int> InputData { get; init; }

        public SARIMAPredictionSettings(
            DateTime predictionFrom, 
            DateTime predictionTo, 
            TimeRangeType timeRangeType,
            List<int> inputData)
        {
            From = predictionFrom;
            To = predictionTo;
            TimeRangeType = timeRangeType;

            InputData = inputData;
        }
    }
}
