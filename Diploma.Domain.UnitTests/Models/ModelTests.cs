using Diploma.Domain.Common.Models;
using Diploma.Domain.Models;
using FluentAssertions;

namespace Diploma.Domain.UnitTests.Models
{
    public class ModelTests
    {
        [Fact]
        public void Constructor_WithValidParameters_ShouldInitializeProperties()
        {
            // Arrange
            var name = "Test Model";
            var type = ModelType.SARIMA;
            var trainingTimeRange = new TrainingTimeRange(
                TimeRangeType.ByDays, 
                DateTime.Now.AddDays(-7), 
                DateTime.Now);

            // Act
            var model = new Model(name, type, trainingTimeRange);

            // Assert
            model.Id.Should().NotBeEmpty();
            model.Name.Should().Be(name);
            model.Type.Should().Be(type);
            model.TrainingTime.Should().Be(trainingTimeRange);
        }

        [Fact]
        public void Constructor_WithCustomId_ShouldInitializeWithProvidedId()
        {
            // Arrange
            var name = "Custom Model";
            var type = ModelType.SARIMA;
            var trainingTimeRange = new TrainingTimeRange(
                TimeRangeType.ByDays, 
                DateTime.Now.AddDays(-3), 
                DateTime.Now);
            var customId = Guid.NewGuid();

            // Act
            var model = new Model(name, type, trainingTimeRange, customId);

            // Assert
            model.Id.Should().Be(customId);
            model.Name.Should().Be(name);
            model.Type.Should().Be(type);
            model.TrainingTime.Should().Be(trainingTimeRange);
        }

        [Fact]
        public void Constructor_WithNullName_ShouldThrowArgumentException()
        {
            // Arrange
            string? name = null;
            var type = ModelType.SARIMA;
            var trainingTimeRange = new TrainingTimeRange(
                TimeRangeType.ByDays, 
                DateTime.Now.AddDays(-5), 
                DateTime.Now);

            // Act
            Action act = () => new Model(name!, type, trainingTimeRange);

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage("Value cannot be null. (Parameter 'name')");
        }

        [Fact]
        public void Constructor_WithNullTrainingTimeRange_ShouldThrowArgumentException()
        {
            // Arrange
            var name = "Invalid Model";
            var type = ModelType.SARIMA;
            TrainingTimeRange? trainingTimeRange = null;

            // Act
            Action act = () => new Model(name, type, trainingTimeRange!);

            // Assert
            act.Should().Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'trainingTimeRange')");
        }

        [Fact]
        public void EFConstructor_ShouldInitializePropertiesToDefaults()
        {
            // Arrange & Act
            var model = new Model();

            // Assert
            model.Id.Should().BeEmpty();
            model.Name.Should().BeNull();
            model.Type.Should().Be(ModelType.None);
            model.TrainingTime.Should().BeNull();
        }
    }
}
