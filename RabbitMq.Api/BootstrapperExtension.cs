using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMq.Client;
using RabbitMQ.Client;
using RabbitMq.Common;
using RabbitMq.MessageGenerator;

namespace RabbitMq.Api;

public static class BootstrapperExtension
{
    public static void RegisterRabbitMqServer(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterMessageGenerator(configuration);

        services.AddSingleton<IRabbitMqProducer, RabbitMqProducer>();
        services.AddSingleton<IProducerConfiguration, ProducerConfiguration>();
        services.AddSingleton<IConnectionFactory>(_ => new ConnectionFactory
        {
            Uri = new Uri(EnvVarReader.GetVariable(EnvironmentVariables.RABBITMQ_CONNECTION_STRING)),
            AutomaticRecoveryEnabled = true,
            NetworkRecoveryInterval = TimeSpan.FromSeconds(5),
        });
    }
}