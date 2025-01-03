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
            var model = ModelFactory.CreateDefaultModel();

            model.Id.Should().NotBeEmpty();
            model.Name.Should().Be(Constants.Models.DefaultName);
            model.Type.Should().Be(Constants.Models.DefaultType);
            model.TrainingTime.Should().Be(Constants.Models.DefaultTimeRange);
        }

        [Fact]
        public void Constructor_WithCustomId_ShouldInitializeWithProvidedId()
        {
            var customId = Guid.NewGuid();

            var model = ModelFactory.CreateDefaultModel(id: customId);

            model.Id.Should().Be(customId);
            model.Name.Should().Be(Constants.Models.DefaultName);
            model.Type.Should().Be(Constants.Models.DefaultType);
            model.TrainingTime.Should().Be(Constants.Models.DefaultTimeRange);
        }

        [Fact]
        public void Constructor_WithNullName_ShouldThrowArgumentException()
        {
            string? name = null;

            Action act = () => new Model(
                name!, 
                Constants.Models.DefaultType, 
                Constants.Models.DefaultTimeRange);

            act.Should().Throw<ArgumentException>()
                .WithMessage("Value cannot be null. (Parameter 'name')");
        }

        [Fact]
        public void Constructor_WithNullTrainingTimeRange_ShouldThrowArgumentException()
        {
            var name = "Invalid Model";

            Action act = () => new Model(
                name!,
                Constants.Models.DefaultType,
                null!);

            act.Should().Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'trainingTimeRange')");
        }

        [Fact]
        public void EFConstructor_ShouldInitializePropertiesToDefaults()
        {
            var model = new Model();

            model.Id.Should().BeEmpty();
            model.Name.Should().BeNull();
            model.Type.Should().Be(ModelType.None);
            model.TrainingTime.Should().BeNull();
        }
    }
}
