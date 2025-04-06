using Diploma.Domain.Common.Models;

namespace Diploma.Domain.Predictions.Settings
{
    /// <summary>
    /// Represents the settings required for generating predictions within a specific time range.
    /// </summary>
    public interface IPredictionSettings
    {
        /// <summary>
        /// Gets the start date of the prediction period.
        /// </summary>
        public DateTime From { get; init; }

        /// <summary>
        /// Gets the end date of the prediction period.
        /// </summary>
        public DateTime To { get; init; }

        /// <summary>
        /// Gets the type of time range used for predictions.
        /// </summary>
        public TimeRangeType TimeRangeType { get; init; }
    }

}
