using Diploma.Domain.Models;

namespace Diploma.Domain.Algorithms
{
    /// <summary>
    /// Represents an algorithm with an associated type and related models
    /// </summary>
    public class Algorithm
    {
        /// <summary>
        /// Gets the unique identifier of the algorithm
        /// </summary>
        public Guid Id { get; init; }

        /// <summary>
        /// Gets the type of the algorithm
        /// </summary>
        public AlgorithmType Type { get; init; }

        /// <summary>
        /// Gets the list of models associated with this algorithm
        /// </summary>
        public virtual List<Model> Models { get; init; } = new();

        /// <summary>
        /// Parameterless constructor required by Entity Framework
        /// </summary>
        public Algorithm() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Algorithm"/> class
        /// </summary>
        /// <param name="type">The type of the algorithm</param>
        /// <param name="models">The list of models associated with the algorithm</param>
        /// <param name="id">The optional unique identifier. If null, a new GUID will be generated</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="models"/> is null</exception>
        public Algorithm(
            AlgorithmType type,
            List<Model> models,
            Guid? id = null)
        {
            ArgumentNullException.ThrowIfNull(models, nameof(models));

            Id = id ?? Guid.NewGuid();
            Type = type;
            Models = models;
        }
    }
}
