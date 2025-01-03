using Diploma.Domain.Common.Helpers;
using Diploma.Domain.Common.Models;

namespace Diploma.Domain.UnitTests.Common.Helpers
{
    public class DateTimeHelperTests
    {
        [Theory]
        [InlineData("2023-01-01", "2023-12-01", 11)]
        [InlineData("2022-01-01", "2023-01-01", 12)]
        [InlineData("2023-01-01", "2023-01-01", 0)]
        [InlineData("2023-01-15", "2023-01-01", 0)]
        [InlineData("2022-12-01", "2023-02-01", 2)]
        public void GetMonthDifference_ShouldReturnCorrectMonthDifference(string fromDate, string toDate, int expectedDifference)
        {
            var from = DateTime.Parse(fromDate);
            var to = DateTime.Parse(toDate);

            var result = DateTimeHelper.GetMonthDifference(from, to);

            Assert.Equal(expectedDifference, result);
        }

        [Theory]
        [InlineData(60, TimeRangeType.BySeconds, 60)] // 60 seconds
        [InlineData(120, TimeRangeType.ByMinutes, 2)] // 2 minutes
        [InlineData(7200, TimeRangeType.ByHours, 2)] // 2 hours
        [InlineData(172800, TimeRangeType.ByDays, 2)] // 2 days
        [InlineData(1209600, TimeRangeType.ByWeeks, 2)] // 2 weeks
        [InlineData(5184000, TimeRangeType.ByMonths, 2)] // Approx. 2 months (30 days each)
        [InlineData(63072000, TimeRangeType.ByYears, 2)] // Approx. 2 years (365 days each)
        public void CalculateDuration_ShouldReturnCorrectDuration(double timeInSeconds, TimeRangeType timeRangeType, double expectedDuration)
        {
            var timeDifference = TimeSpan.FromSeconds(timeInSeconds);

            var result = DateTimeHelper.CalculateDuration(timeRangeType, timeDifference);

            Assert.Equal(expectedDuration, result, precision: 5); // Allow precision up to 5 decimal places
        }

        [Fact]
        public void CalculateDuration_WithUnsupportedTimeRangeType_ShouldThrowInvalidOperationException()
        {
            var timeDifference = TimeSpan.FromDays(1);
            var unsupportedType = (TimeRangeType)(-1); // Invalid enum value

            Assert.Throws<InvalidOperationException>(() =>
                DateTimeHelper.CalculateDuration(unsupportedType, timeDifference));
        }
    }
}
