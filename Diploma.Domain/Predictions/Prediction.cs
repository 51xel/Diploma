namespace Diploma.Domain.Predictions
{
    public class Prediction
    {
        public DateTime Time { get; init; }
        public double Price { get; init; }

        public Prediction(DateTime time, double price)
        {
            Time = time;
            Price = price;
        }
    }
}
