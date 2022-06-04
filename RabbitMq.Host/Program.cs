using RabbitMq.Host;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.ConfigureRabbitMqService();
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
