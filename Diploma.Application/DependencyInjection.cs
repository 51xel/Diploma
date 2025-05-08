using Diploma.Application.Algotihms.Factories;
using Diploma.Application.Algotihms.Interfaces;
using Diploma.Application.Algotihms.Services;
using Diploma.Application.Algotihms.Services.AlgorithmProcessors;
using Diploma.Application.Models.Interfaces;
using Diploma.Application.Models.Services;
using Diploma.Application.Predictions.Factories;
using Diploma.Application.Predictions.Interfaces;
using Diploma.Application.Predictions.Services.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace Diploma.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection));
            });

            services.AddTransient<IModelFileCacheService, ModelFileCacheService>();
            services.AddTransient<IAlgorithmService, AlgorithmService>();
            services.AddTransient<IPredictionSettingsService, SarimaPredictionSettingsService>();

            services.AddTransient<IPredictionSettingsFactory, PredictionSettingsFactory>();
            services.AddTransient<IPredictionRepositoryFactory, PredictionRepositoryFactory>();
            services.AddTransient<IAlgorithmProcessorFactory, AlgorithmProcessorFactory>();

            services.AddTransient<IAlgorithmProcessor, BTCProcessor>();

            return services;
        }
    }
}
