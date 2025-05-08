using Diploma.Domain.Algorithms;
using Diploma.Domain.Predictions;
using Diploma.Domain.TradeActions;

namespace Diploma.Domain.Actions
{
    public class TradeAction
    {
        public Guid Id { get; init; }
        public DateTime ActAt { get; init; }
        public TradeActionType Type { get; init; }
        public double PredictedPrice { get; set; }

        public virtual Algorithm Algorithm { get; init; }

        //EF
        public TradeAction() {}

        public TradeAction(
            DateTime actAt,
            TradeActionType type,
            double predictedPrice,
            Algorithm algorithm,
            Guid? id = null)
        {
            ArgumentNullException.ThrowIfNull(algorithm, nameof(algorithm));

            Id = id ?? Guid.NewGuid();
            ActAt = actAt;
            Type = type;
            PredictedPrice = predictedPrice;
            Algorithm = algorithm;
        }

        public TradeAction(
            Prediction prediction,
            TradeActionType type,
            Algorithm algorithm)
            : this(prediction.Time, type, prediction.Price, algorithm)
        {
        }
    }
}
