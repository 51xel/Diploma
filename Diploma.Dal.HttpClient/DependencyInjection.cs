using Diploma.Application.Predictions.Interfaces;
using Diploma.Dal.HttpClient.Common.Settings;
using Diploma.Dal.HttpClient.Predictions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Diploma.Dal.HttpClient
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDalHttpClient(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddHttpClient();

            services.Configure<HttpClientSettings>(configuration.GetSection("HttpClientSettings"));

            services.AddTransient<IExternalPredictionRepository, ExternalPredictionRepository>();

            return services;
        }
    }
}
