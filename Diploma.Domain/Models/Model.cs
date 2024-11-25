namespace Diploma.Domain.Models
{
    public class Model
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public ModelType Type { get; init; }
        public TrainingTimeRange TrainingTime { get; set; }

        // EF
        public Model() { }

        public Model( 
            string name, 
            ModelType type, 
            TrainingTimeRange trainingTimeRange,
            Guid? id = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            ArgumentNullException.ThrowIfNull(trainingTimeRange, nameof(trainingTimeRange));

            Id = id ?? Guid.NewGuid();
            Name = name;
            Type = type;
            TrainingTime = trainingTimeRange;
        }
    }
}