using RabbitMq.Client;
using RabbitMq.MessageGenerator;

namespace RabbitMq.Api
{
    internal class RabbitMqProducer : IRabbitMqProducer
    {
        private readonly IMessageGenerator _messageGenerator;

        public RabbitMqProducer(IMessageGenerator messageGenerator)
        {
            _messageGenerator = messageGenerator;
        }

        public Task SendRandomMessage()
        {
            var generate = _messageGenerator.Generate();
            return Task.CompletedTask;
        }
    }
}