using Diploma.Application.Predictions.Interfaces;
using Diploma.Contracts.Predictions;
using Diploma.Dal.HttpClient.Common.Settings;
using Diploma.Domain.Predictions;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Diploma.Dal.HttpClient.Predictions
{
    internal class ExternalPredictionRepository : IExternalPredictionRepository
    {
        private readonly System.Net.Http.HttpClient _httpClient;
        private readonly HttpClientSettings _httpClientSettings;

        public ExternalPredictionRepository(
            IHttpClientFactory httpClientFactory,
            IOptions<HttpClientSettings> httpClientSettings)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClientSettings = httpClientSettings.Value;
        }

        public async Task<IEnumerable<Prediction>> GetPredictionsAsync(Guid modelId, DateTime from, DateTime to)
        {
            var request = new PredictPriceRequest(modelId, from, to);

            var response = await _httpClient.PostAsJsonAsync(
                _httpClientSettings.PredictPriceUri, 
                request);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed to fetch predictions. Status: {response.StatusCode}");
            }

            var predictionEntities = await response.Content.ReadFromJsonAsync<IEnumerable<PredictPriceResponse>>();

            if (predictionEntities is null)
            {
                return Enumerable.Empty<Prediction>();
            }

            return predictionEntities.Select(predictionEntity => new Prediction(predictionEntity.Time, predictionEntity.Price));
        }
    }
}
