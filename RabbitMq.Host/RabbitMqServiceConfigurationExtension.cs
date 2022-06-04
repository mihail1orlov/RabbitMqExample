using RabbitMq.Api;

namespace RabbitMq.Host;

/// <summary>
/// A class that configures the RabbitMq service configuration.
/// </summary>
public static class RabbitMqServiceConfigurationExtension
{
    public static void ConfigureRabbitMqService(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        services.RegisterRabbitMqServer(configuration);
    }
}