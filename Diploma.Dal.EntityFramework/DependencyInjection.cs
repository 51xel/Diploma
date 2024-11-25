using Diploma.Application.Models.Interfaces;
using Diploma.Dal.EntityFramework.Common;
using Diploma.Dal.EntityFramework.Models;
using Microsoft.Azure.Cosmos;
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
            services.AddDbContextFactory<CosmosDbContext>(optionsBuilder => optionsBuilder.UseCosmos(
                connectionString: configuration.GetConnectionString("CosmosDb")!,
                databaseName: configuration["CosmosDbSettings:DatabaseName"]!,
                cosmosOptionsAction: options =>
                {
                    options.ConnectionMode(ConnectionMode.Direct);
                    options.MaxRequestsPerTcpConnection(16);
                    options.MaxTcpConnectionsPerEndpoint(32);
                    options.HttpClientFactory(() => new HttpClient(new HttpClientHandler
                    {
                        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                    }));
                }
            ));

            return services;
        }
    }
}
