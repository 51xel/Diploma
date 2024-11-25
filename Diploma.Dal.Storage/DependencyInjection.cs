using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Azure.Storage.Blobs;
using Diploma.Dal.Storage.Common.Settings;
using Diploma.Dal.Storage.Models;
using Diploma.Application.Models.Interfaces;

namespace Diploma.Dal.Storage
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDalStorage(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton(x => new BlobServiceClient(
                configuration.GetConnectionString("StorageAccount")));

            services.Configure<StorageAccountSettings>(configuration.GetSection("StorageAccountSettings"));

            services.AddTransient<IModelFileRepository, ModelFileRepository>();

            return services;
        }
    }
}
