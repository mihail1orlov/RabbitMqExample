namespace RabbitMq.Api;

internal interface IProducerConfiguration
{
    int Ttl { get; }
    string ExchangeName { get; }
    string RoutingKey { get; }
    string ExchangeType { get; }
    bool Durable { get; }
}