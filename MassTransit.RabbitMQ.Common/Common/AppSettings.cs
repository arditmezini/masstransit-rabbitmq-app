using MassTransit.RabbitMQ.Common.Models;
using Microsoft.Extensions.Configuration;

namespace MassTransit.RabbitMQ.Common.Common
{
    public static class AppSettings
    {
        static AppSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }

        private static IConfiguration Configuration { get; }
        public static RabbitMqConfigurations RabbitMqConfigurations => Configuration.GetSection("RabbitMQConfigurations").Get<RabbitMqConfigurations>();
    }
}