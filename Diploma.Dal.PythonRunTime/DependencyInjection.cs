using Diploma.Application.Predictions.Interfaces;
using Diploma.Dal.PythonRunTime.Predictions;
using Microsoft.Extensions.DependencyInjection;
using Python.Runtime;

namespace Diploma.Dal.PythonRunTime
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDalPythonRunTime(this IServiceCollection services)
        {
            services.AddScoped<IPredictionRepository, SARIMAPredictionRepository>();

            return services;
        }
    }
}
