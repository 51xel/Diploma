using Diploma.Domain.Algorithms;

namespace Diploma.Domain.Models
{
    /// <summary>
    /// Represents a machine learning with associated algorithms.
    /// </summary>
    public class Model
    {
        /// <summary>
        /// Gets the unique identifier of the model
        /// </summary>
        public Guid Id { get; init; }

        /// <summary>
        /// Gets the name of the model
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Gets the type of the model
        /// </summary>
        public ModelType Type { get; init; }

        /// <summary>
        /// Gets the training time range for this model
        /// </summary>
        public TrainingTimeRange TrainingTime { get; init; }

        /// <summary>
        /// Gets the list of algorithms associated with this model
        /// </summary>
        public virtual List<Algorithm> Algorithms { get; init; } = new();

        /// <summary>
        /// Parameterless constructor required by Entity Framework
        /// </summary>
        public Model() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Model"/> class
        /// </summary>
        /// <param name="name">The name of the model.</param>
        /// <param name="type">The type of the model.</param>
        /// <param name="trainingTimeRange">The training time range associated with the model</param>
        /// <param name="algorithms">The list of algorithms associated with the model</param>
        /// <param name="id">The optional unique identifier. If null, a new GUID will be generated</param>
        /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is null or empty</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="trainingTimeRange"/> or <paramref name="algorithms"/> is null</exception>
        public Model(
            string name,
            ModelType type,
            TrainingTimeRange trainingTimeRange,
            List<Algorithm> algorithms,
            Guid? id = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            ArgumentNullException.ThrowIfNull(trainingTimeRange, nameof(trainingTimeRange));
            ArgumentNullException.ThrowIfNull(algorithms, nameof(algorithms));

            Id = id ?? Guid.NewGuid();
            Name = name;
            Type = type;
            TrainingTime = trainingTimeRange;
            Algorithms = algorithms;
        }
    }
}