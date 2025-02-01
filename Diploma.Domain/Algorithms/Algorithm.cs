using Diploma.Domain.Models;

namespace Diploma.Domain.Algorithms
{
    public class Algorithm
    {
        public Guid Id { get; init; }
        public AlgorithmType Type { get; init; }

        public virtual List<Model> Models { get; init; } = new();

        //EF
        public Algorithm() {}

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
