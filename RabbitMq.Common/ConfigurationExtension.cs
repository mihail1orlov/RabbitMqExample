using Microsoft.Extensions.Configuration;

namespace RabbitMq.Common
{
    public static class ConfigurationExtension
    {

        public static string GetEnvVar(this IConfiguration configuration, string value)
        {
            var ret = Environment.GetEnvironmentVariable(value)
                      ?? configuration[value];
            return ret;
        }
    }
}