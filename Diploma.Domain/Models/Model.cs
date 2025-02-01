using Diploma.Domain.Algorithms;

namespace Diploma.Domain.Models
{
    public class Model
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public ModelType Type { get; init; }
        public TrainingTimeRange TrainingTime { get; init; }

        public virtual List<Algorithm> Algorithms { get; init; } = new();

        // EF
        public Model() { }

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