using Diploma.Domain.Models;
using Diploma.Tests.Common.Models;
using Diploma.Tests.Common.TestConstants;
using FluentAssertions;

namespace Diploma.Domain.UnitTests.Models
{
    public class ModelTests
    {
        [Fact]
        public void Constructor_WithValidParameters_ShouldInitializeProperties()
        {
            // Arrange
            // Act
            var model = ModelFactory.CreateDefaultModel();

            // Assert
            model.Id.Should().NotBeEmpty();
            model.Name.Should().Be(Constants.Models.DefaultName);
            model.Type.Should().Be(Constants.Models.DefaultType);
            model.TrainingTime.Should().Be(Constants.Models.DefaultTimeRange);
        }

        [Fact]
        public void Constructor_WithCustomId_ShouldInitializeWithProvidedId()
        {
            // Arrange
            var customId = Guid.NewGuid();

            // Act
            var model = ModelFactory.CreateDefaultModel(id: customId);

            // Assert
            model.Id.Should().Be(customId);
            model.Name.Should().Be(Constants.Models.DefaultName);
            model.Type.Should().Be(Constants.Models.DefaultType);
            model.TrainingTime.Should().Be(Constants.Models.DefaultTimeRange);
        }

        [Fact]
        public void Constructor_WithNullName_ShouldThrowArgumentException()
        {
            // Arrange
            string? name = null;

            // Act
            Action act = () => new Model(
                name!, 
                Constants.Models.DefaultType, 
                Constants.Models.DefaultTimeRange);

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage("Value cannot be null. (Parameter 'name')");
        }

        [Fact]
        public void Constructor_WithNullTrainingTimeRange_ShouldThrowArgumentException()
        {
            // Arrange
            var name = "Invalid Model";

            // Act
            Action act = () => new Model(
                name!,
                Constants.Models.DefaultType,
                null!);

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
