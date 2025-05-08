using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Diploma.Application;
using Diploma.Dal.EntityFramework;
using Diploma.Dal.HttpClient;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;

[assembly: FunctionsStartup(typeof(AlgorithmProcessing.Startup))]

namespace AlgorithmProcessing
{
    public class Startup : FunctionsStartup
    {
        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            var builtConfig = builder.ConfigurationBuilder.Build();
            var keyVaultUri = builtConfig["AzureKeyVaultUri"];

            if (!string.IsNullOrEmpty(keyVaultUri))
            {
                builder.ConfigurationBuilder.AddAzureKeyVault(
                    new Uri(keyVaultUri),
                    new DefaultAzureCredential(),
                    new AzureKeyVaultConfigurationOptions
                    {
                        Manager = new KeyVaultSecretManager()
                    });
            }
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = builder.GetContext().Configuration;

            builder.Services
                .AddApplication()
                .AddDalEntityFramework(configuration)
                .AddDalHttpClient(configuration);
        }
    }
}
