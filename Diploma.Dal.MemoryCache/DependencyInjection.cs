using Diploma.Application.Models.Interfaces;
using Diploma.Dal.MemoryCache.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Diploma.Dal.PythonRunTime
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDalMemorysCache(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddTransient<IModelFileCacheRepository, ModelFileMemoryCacheRepository>();

            return services;
        }
    }
}
