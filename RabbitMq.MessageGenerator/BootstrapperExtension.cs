using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RabbitMq.MessageGenerator;

public static class BootstrapperExtension
{
    public static void RegisterMessageGenerator(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IMessageGenerator, MessageGenerator>();
    }
}