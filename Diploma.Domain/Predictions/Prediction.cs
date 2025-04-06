namespace Diploma.Domain.Predictions
{
    /// <summary>
    /// Represents a price prediction at a specific point in time
    /// </summary>
    public class Prediction
    {
        /// <summary>
        /// Gets the timestamp of the prediction
        /// </summary>
        public DateTime Time { get; init; }

        /// <summary>
        /// Gets the predicted price
        /// </summary>
        public double Price { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Prediction"/> class
        /// </summary>
        /// <param name="time">The timestamp of the prediction</param>
        /// <param name="price">The predicted price value</param>
        public Prediction(DateTime time, double price)
        {
            Time = time;
            Price = price;
        }
    }
}
