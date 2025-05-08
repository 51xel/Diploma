using Diploma.Application.Algotihms.Interfaces;
using Diploma.Application.Models.Interfaces;
using Diploma.Application.TradeActions.Interfaces;
using Diploma.Dal.EntityFramework.Algorithms;
using Diploma.Dal.EntityFramework.Common;
using Diploma.Dal.EntityFramework.Models;
using Diploma.Dal.EntityFramework.TradeActions;
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
            services.AddTransient<IAlgorithmRepository, AlgorithmRepository>();
            services.AddTransient<ITradeActionRepository, TradeActionRepository>();
            services.AddTransient<ITradePairRepository, TradePairRepository>();

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
