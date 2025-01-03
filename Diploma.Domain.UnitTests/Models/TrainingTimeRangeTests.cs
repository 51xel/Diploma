using Diploma.Domain.Common.Models;
using Diploma.Domain.Models;
using Diploma.Tests.Common.Models;
using Diploma.Tests.Common.TestConstants;
using FluentAssertions;

namespace Diploma.Domain.UnitTests.Models
{
    public class TrainingTimeRangeTests
    {
        public static IEnumerable<object[]> TimeRangeValidationData => Constants.TrainingTimeRange.ValidationData;

        [Fact]
        public void Constructor_WithValidParameters_ShouldInitializeProperties()
        {
            var range = TrainingTimeRangeFactory.CreateDefault();

            range.Type.Should().Be(Constants.TrainingTimeRange.DefaultTimeRangeType);
            range.From.Should().Be(Constants.TrainingTimeRange.DefaultFrom);
            range.To.Should().Be(Constants.TrainingTimeRange.DefaultTo);
        }

        [Fact]
        public void Constructor_WithInvalidDateRange_ShouldThrowArgumentException()
        {
            var type = TimeRangeType.ByDays;
            var from = DateTime.Now;
            var to = DateTime.Now.AddDays(-1);

            Action act = () => new TrainingTimeRange(type, from, to);

            act.Should().Throw<ArgumentException>()
                .WithMessage("The 'From' date must be earlier than the 'To' date.");
        }

        [Fact]
        public void Constructor_WithInvalidTimeRangeType_ShouldThrowArgumentException()
        {
            var type = TimeRangeType.ByYears;
            var from = DateTime.Now.AddMonths(-6);
            var to = DateTime.Now;

            Action act = () => new TrainingTimeRange(type, from, to);

            act.Should().Throw<ArgumentException>()
                .WithMessage($"The specified time range '{type}' is invalid for the given dates: from({from}), to({to})");
        }

        [Theory]
        [MemberData(nameof(TimeRangeValidationData))]
        public void Constructor_WithVariousTimeRangeTypes_ShouldValidateCorrectly(
            TimeRangeType type,
            double daysFrom,
            double hoursFrom,
            double minutesFrom,
            double secondsFrom,
            double secondsTo,
            bool isValid)
        {
            // Arrange
            var from = DateTime.Now.AddDays(daysFrom)
                                   .AddHours(hoursFrom)
                                   .AddMinutes(minutesFrom)
                                   .AddSeconds(secondsFrom);

            var to = from.AddSeconds(secondsTo);

            Action act = () => new TrainingTimeRange(type, from, to);

            if (isValid)
            {
                act.Should().NotThrow();
            }
            else
            {
                act.Should().Throw<ArgumentException>()
                    .WithMessage($"The specified time range '{type}' is invalid for the given dates: from({from}), to({to})");
            }
        }

        [Fact]
        public void EFConstructor_ShouldInitializePropertiesToDefaults()
        {
            var range = new TrainingTimeRange();

            range.Type.Should().Be(TimeRangeType.None);
            range.From.Should().Be(default);
            range.To.Should().Be(default);
        }
    }
}
