namespace Diploma.Dal.HttpClient.Common.Settings
{
    class HttpClientSettings
    {
        public required Uri PredictionApiHost { get; init; }
        public required Uri PredictPricePath { get; init; }
        public Uri PredictPriceUri => new Uri(PredictionApiHost, PredictPricePath);
    }
}
