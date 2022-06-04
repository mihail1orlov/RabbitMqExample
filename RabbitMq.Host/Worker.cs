using RabbitMq.Client;

namespace RabbitMq.Host;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IRabbitMqProducer _rabbitMqProducer;

    public Worker(ILogger<Worker> logger, IRabbitMqProducer rabbitMqProducer)
    {
        _logger = logger;
        _rabbitMqProducer = rabbitMqProducer;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _rabbitMqProducer.SendRandomMessage();
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }
}