using Diploma.Domain.Common.Helpers;
using Diploma.Domain.Common.Models;

namespace Diploma.Domain.Models
{
    /// <summary>
    /// Represents a time range used for training models
    /// </summary>
    public class TrainingTimeRange
    {
        /// <summary>
        /// Gets the type of time range (e.g., seconds, minutes, days, etc.)
        /// </summary>
        public TimeRangeType Type { get; init; }

        /// <summary>
        /// Gets the start date and time of the training period
        /// </summary>
        public DateTime From { get; init; }

        /// <summary>
        /// Gets the end date and time of the training period
        /// </summary>
        public DateTime To { get; init; }

        /// <summary>
        /// Parameterless constructor required by Entity Framework
        /// </summary>
        public TrainingTimeRange() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrainingTimeRange"/> class
        /// </summary>
        /// <param name="trainingTimeRangeType">The type of time range used for training</param>
        /// <param name="from">The start date and time of the training period</param>
        /// <param name="to">The end date and time of the training period</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="from"/> is greater than or equal to <paramref name="to"/> 
        /// or if the specified time range type is invalid for the given dates</exception>
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
            return trainingTimeRangeType switch
            {
                TimeRangeType.BySeconds => (to - from).TotalSeconds >= 1,
                TimeRangeType.ByMinutes => (to - from).TotalMinutes >= 1,
                TimeRangeType.ByHours => (to - from).TotalHours >= 1,
                TimeRangeType.ByDays => (to - from).TotalDays >= 1,
                TimeRangeType.ByMonths => DateTimeHelper.GetMonthDifference(from, to) >= 1,
                TimeRangeType.ByYears => (to.Year - from.Year) >= 1,
                _ => throw new InvalidOperationException($"Unsupported time range type: {trainingTimeRangeType}")
            };
        }
    }
}
