namespace Diploma.Contracts.Predictions
{
    public record PredictPriceRequest(Guid ModelId, DateTime From, DateTime To);
}
