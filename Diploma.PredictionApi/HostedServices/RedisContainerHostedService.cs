using Testcontainers.Redis;

namespace Diploma.PredictionApi.HostedServices
{
    public class RedisContainerHostedService : IHostedService
    {
        private readonly ILogger<RedisContainerHostedService> _logger;
        private readonly IHostApplicationLifetime _appLifetime;

        public RedisContainerHostedService(ILogger<RedisContainerHostedService> logger, IHostApplicationLifetime appLifetime)
        {
            _logger = logger;
            _appLifetime = appLifetime;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                var loggerFactory = LoggerFactory.Create(builder => builder.SetMinimumLevel(LogLevel.None));

                var redisContainer = new RedisBuilder()
                    .WithImage("redis")
                    .WithPortBinding(6379)
                    .WithDockerEndpoint("tcp://localhost:2375")
                    .WithReuse(true)
                    .WithLogger(loggerFactory.CreateLogger<RedisContainerHostedService>())
                    .Build();

                await redisContainer.StartAsync(cancellationToken);

                _logger.LogInformation($"Redis container started with ID: {redisContainer.Id}");
            }
            catch (HttpRequestException)
            {
                _logger.LogError("Failed to start Redis container. Ensure Docker is running and accessible. https://gist.github.com/sz763/3b0a5909a03bf2c9c5a057d032bd98b7");
                _appLifetime.StopApplication();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
