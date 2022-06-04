namespace RabbitMq.Client;

public interface IRabbitMqProducer
{
    Task SendRandomMessage();
}