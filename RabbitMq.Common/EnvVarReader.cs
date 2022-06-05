using System.Text.Json;

namespace RabbitMq.Common
{
    public static class EnvVarReader
    {

        public static string GetVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name)
                   ?? throw new ArgumentNullException($"Environment variable '{name}' cannot be null");
        }

        public static T GetVariable<T>(this T _, string name)
        {
            var variable = GetVariable(name);
            return JsonSerializer.Deserialize<T>(variable)
                   ?? throw new ArgumentNullException($"Environment variable '{name}' cannot be null");
        }
    }
}