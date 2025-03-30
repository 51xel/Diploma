using Diploma.Application.Predictions.Interfaces;
using Diploma.Dal.PythonRunTime.Predictions;
using Microsoft.Extensions.DependencyInjection;

namespace Diploma.Dal.PythonRunTime
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDalPythonRunTime(this IServiceCollection services)
        {
            services.AddTransient<IPredictionRepository, SarimaPredictionRepository>();

            return services;
        }
    }
}
