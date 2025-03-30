using Diploma.Domain.Common.Models;
using Diploma.Domain.Predictions.Settings;

namespace Diploma.Domain.Common.Helpers
{
    public static class DateTimeHelper
    {
        public static int GetMonthDifference(DateTime from, DateTime to)
        {
            return (to.Year - from.Year) * 12 + (to.Month - from.Month);
        }

        public static double CalculateDuration(TimeRangeType timeRangeType, TimeSpan timeDifference)
        {
            return timeRangeType switch
            {
                TimeRangeType.BySeconds => timeDifference.TotalSeconds,
                TimeRangeType.ByMinutes => timeDifference.TotalMinutes,
                TimeRangeType.ByHours => timeDifference.TotalHours,
                TimeRangeType.ByDays => timeDifference.TotalDays,
                TimeRangeType.ByWeeks => timeDifference.TotalDays / 7,
                TimeRangeType.ByMonths => timeDifference.TotalDays / 30,
                TimeRangeType.ByYears => timeDifference.TotalDays / 365,
                _ => throw new InvalidOperationException("Unsupported time range type")
            };
        }

        public static DateTime AddTime(this DateTime dateTime, TimeRangeType timeRangeType, double amount)
        {
            return timeRangeType switch
            {
                TimeRangeType.BySeconds => dateTime.AddSeconds(amount),
                TimeRangeType.ByMinutes => dateTime.AddMinutes(amount),
                TimeRangeType.ByHours => dateTime.AddHours(amount),
                TimeRangeType.ByDays => dateTime.AddDays(amount),
                TimeRangeType.ByWeeks => dateTime.AddDays(amount * 7),
                TimeRangeType.ByMonths => dateTime.AddMonths((int)amount),
                TimeRangeType.ByYears => dateTime.AddYears((int)amount),
                _ => throw new InvalidOperationException("Unsupported time range type")
            };
        }

        public static double CalculateInterval(SarimaPredictionSettings sarimaSettings)
        {
            var totalPredictions = sarimaSettings.InputData.Count;
            var predictionDifference = sarimaSettings.To - sarimaSettings.From;
            var predictionDuration = CalculateDuration(sarimaSettings.TimeRangeType, predictionDifference);

            return predictionDuration / (totalPredictions - 1);
        }
    }
}
