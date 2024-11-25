using Diploma.Application.Models.Interfaces;
using Diploma.Application.Models.Services;
using Diploma.Application.Predictions.Factories;
using Diploma.Application.Predictions.Factories.Interfaces;
using Diploma.Application.Predictions.Interfaces;
using Diploma.Application.Predictions.Services;
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

            services.AddTransient<IModelCacheService, ModelCacheService>();

            services.AddTransient<IPredictionSettingsFactory, PredictionSettingsFactory>();
            services.AddTransient<IPredictionRepositoryFactory, PredictionRepositoryFactory>();

            services.AddTransient<IPredictionSettingsService, SARIMAPredictionSettingsService>();

            return services;
        }
    }
}
