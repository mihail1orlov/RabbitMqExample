using Microsoft.Extensions.Logging;
using RabbitMq.Client;
using RabbitMq.MessageGenerator;
using RabbitMQ.Client;

namespace RabbitMq.Api
{
    internal class RabbitMqProducer : IRabbitMqProducer
    {
        private readonly ILogger<RabbitMqProducer> _logger;
        private readonly IMessageGenerator _messageGenerator;
        private readonly IConnectionFactory _connectionFactory;
        private readonly IProducerConfiguration _configuration;

        public RabbitMqProducer(ILogger<RabbitMqProducer> logger,
            IMessageGenerator messageGenerator,
            IConnectionFactory connectionFactory,
            IProducerConfiguration configuration)
        {
            _logger = logger;
            _messageGenerator = messageGenerator;
            _connectionFactory = connectionFactory;
            _configuration = configuration;
            _logger.LogInformation(_configuration.ToString());
        }

        public Task SendRandomMessage()
        {
            using var connection = _connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();

            var body = _messageGenerator.Generate();

            var ttl = _configuration.Ttl <= 0 ? null : new Dictionary<string, object>
            {
                {"x-message-ttl", _configuration.Ttl }
            };

            var exchangeType = _configuration.ExchangeType.ToLower();

            channel.ExchangeDeclare(_configuration.ExchangeName, exchangeType, _configuration.Durable, arguments: ttl);

            channel.BasicPublish(_configuration.ExchangeName, _configuration.RoutingKey, null, body);

            return Task.CompletedTask;
        }
    }
}