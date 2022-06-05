using RabbitMq.Common;

namespace RabbitMq.Api;

internal class ProducerConfiguration : IProducerConfiguration
{
    public ProducerConfiguration()
    {
        ExchangeName = EnvVarReader.GetVariable(EnvironmentVariables.RABBITMQ_EXCHANGE);
        ExchangeType = EnvVarReader.GetVariable(EnvironmentVariables.RABBITMQ_EXCHANGE_TYPE);
        RoutingKey = EnvVarReader.GetVariable(EnvironmentVariables.RABBITMQ_ROUTING_KEY);
        Durable = Durable.GetVariable(EnvironmentVariables.RABBITMQ_DURABLE);
    }

    public int Ttl { get; } = 15000;

    public string ExchangeName { get; }

    public string RoutingKey { get; }

    public string ExchangeType { get; }

    public bool Durable { get; }

    public override string ToString()
    {
        return $"{nameof(Ttl)}: {Ttl},\n{nameof(ExchangeName)}: {ExchangeName},\n{nameof(RoutingKey)}: {RoutingKey},\n{nameof(ExchangeType)}: {ExchangeType},\n{nameof(Durable)}: {Durable}";
    }
}