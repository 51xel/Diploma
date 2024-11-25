using Diploma.Domain.Common.Models;

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
    }
}
