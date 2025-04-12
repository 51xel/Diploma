using Diploma.Application.Models.Interfaces;
using Diploma.Dal.RedisCache.Common.Settings;
using Diploma.Dal.RedisCache.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Diploma.Dal.RedisCache
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDalRedisCache(
            this IServiceCollection services,
            IConfiguration configuration,
            bool isDevelopment)
        {
            if (isDevelopment)
            {
                services.AddStackExchangeRedisCache(options =>
                {
                    options.Configuration = configuration.GetConnectionString("LocalRedis")!;
                });

                services.Configure<RedisCacheSettings>(configuration.GetSection("RedisCacheSettings"));

                services.AddTransient<IModelFileCacheRepository, ModelFileRedisCacheRepository>();
            }

            return services;
        }
    }
}
