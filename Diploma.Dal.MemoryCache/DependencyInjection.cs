using Diploma.Application.Models.Interfaces;
using Diploma.Dal.MemoryCache.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Diploma.Dal.MemoryCache
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDalMemoryCache(this IServiceCollection services)
        {
            services.AddSingleton<IModelCacheRepository, ModelCacheRepository>();

            return services;
        }
    }
}
