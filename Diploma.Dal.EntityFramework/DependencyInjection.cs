using Diploma.Application.Models.Interfaces;
using Diploma.Dal.EntityFramework.Common;
using Diploma.Dal.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Diploma.Dal.EntityFramework
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDalEntityFramework(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.ConfigureEntityFramework(configuration);

            services.AddTransient<IModelRepository, ModelRepository>();

            return services;
        }

        private static IServiceCollection ConfigureEntityFramework(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options
                    .UseSqlServer(configuration.GetConnectionString("AzureSql"))
                    .UseLazyLoadingProxies());

            return services;
        }
    }
}
