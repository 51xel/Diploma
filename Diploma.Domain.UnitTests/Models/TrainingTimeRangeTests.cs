using Diploma.Domain.Common.Models;
using Diploma.Domain.Models;
using FluentAssertions;

namespace Diploma.Domain.UnitTests.Models
{
    public class TrainingTimeRangeTests
    {
        [Fact]
        public void Constructor_WithValidParameters_ShouldInitializeProperties()
        {
            // Arrange
            var type = TimeRangeType.ByDays;
            var from = DateTime.Now.AddDays(-7);
            var to = DateTime.Now;

            // Act
            var range = new TrainingTimeRange(type, from, to);

            // Assert
            range.Type.Should().Be(type);
            range.From.Should().Be(from);
            range.To.Should().Be(to);
        }

        [Fact]
        public void Constructor_WithInvalidDateRange_ShouldThrowArgumentException()
        {
            // Arrange
            var type = TimeRangeType.ByDays;
            var from = DateTime.Now;
            var to = DateTime.Now.AddDays(-1);

            // Act
            Action act = () => new TrainingTimeRange(type, from, to);

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage("The 'From' date must be earlier than the 'To' date.");
        }

        [Fact]
        public void Constructor_WithInvalidTimeRangeType_ShouldThrowArgumentException()
        {
            // Arrange
            var type = TimeRangeType.ByYears;
            var from = DateTime.Now.AddMonths(-6);
            var to = DateTime.Now;

            // Act
            Action act = () => new TrainingTimeRange(type, from, to);

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage($"The specified time range '{type}' is invalid for the given dates: from({from}), to({to})");
        }

        [Theory]
        //                                    d  h  m  sf st  
        [InlineData(TimeRangeType.BySeconds, -5, 0, 0, 0, 1, true)] // Valid: BySeconds >= 1
        [InlineData(TimeRangeType.BySeconds, 0, 0, 0, 0, 0.9, false)] // Invalid: BySeconds < 1
        [InlineData(TimeRangeType.ByMinutes, -1, 0, 0, 0, 60, true)] // Valid: ByMinutes >= 1
        [InlineData(TimeRangeType.ByMinutes, -1, 0, 0, 0, 59, false)] // Invalid: ByMinutes < 1
        [InlineData(TimeRangeType.ByHours, 0, -2, 0, 0, 3600, true)] // Valid: ByHours >= 1
        [InlineData(TimeRangeType.ByHours, 0, -1, 0, 0, 3599, false)] // Invalid: ByHours < 1
        [InlineData(TimeRangeType.ByDays, -7, 0, 0, 0, 86400, true)] // Valid: ByDays >= 1
        [InlineData(TimeRangeType.ByDays, -1, 0.5, 0, 0, 60, false)] // Invalid: ByDays < 1
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

            // Act
            Action act = () => new TrainingTimeRange(type, from, to);

            // Assert
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
            // Arrange & Act
            var range = new TrainingTimeRange();

            // Assert
            range.Type.Should().Be(TimeRangeType.None);
            range.From.Should().Be(default);
            range.To.Should().Be(default);
        }
    }
}
