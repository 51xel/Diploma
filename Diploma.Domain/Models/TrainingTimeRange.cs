using Diploma.Domain.Common.Helpers;
using Diploma.Domain.Common.Models;

namespace Diploma.Domain.Models
{
    public class TrainingTimeRange
    {
        public TimeRangeType Type { get; init; }
        public DateTime From { get; init; }
        public DateTime To { get; init; }

        // EF
        public TrainingTimeRange() { }

        public TrainingTimeRange(
            TimeRangeType trainingTimeRangeType, 
            DateTime from, 
            DateTime to)
        {
            if (from >= to)
            {
                throw new ArgumentException("The 'From' date must be earlier than the 'To' date.");
            }

            if (!ValidateTrainingTimeRangeType(trainingTimeRangeType, from, to))
            {
                throw new ArgumentException($"The specified time range '{trainingTimeRangeType}' is invalid for the given dates: from({from}), to({to})");
            }

            Type = trainingTimeRangeType;
            From = from;
            To = to;
        }

        private bool ValidateTrainingTimeRangeType(
            TimeRangeType trainingTimeRangeType,
            DateTime from,
            DateTime to)
        {
            switch (trainingTimeRangeType)
            {
                case TimeRangeType.BySeconds:
                    return (to - from).TotalSeconds >= 1;
                case TimeRangeType.ByMinutes:
                    return (to - from).TotalMinutes >= 1;
                case TimeRangeType.ByHours:
                    return (to - from).TotalHours >= 1;
                case TimeRangeType.ByDays:
                    return (to - from).TotalDays >= 1;
                case TimeRangeType.ByMonths:
                    return DateTimeHelper.GetMonthDifference(from, to) >= 1;
                case TimeRangeType.ByYears:
                    return (to.Year - from.Year) >= 1;
                default:
                    throw new InvalidOperationException($"Unsupported time range type: {trainingTimeRangeType}");
            }
        }
    }
}
