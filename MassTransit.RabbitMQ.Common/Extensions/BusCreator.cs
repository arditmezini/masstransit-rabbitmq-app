using MassTransit.RabbitMQ.Common.Models;
using MassTransit.RabbitMqTransport;
using System;

namespace MassTransit.RabbitMQ.Common.Extensions
{
    public static class BusCreator
    {
        public static IBusControl Create(RabbitMqConfigurations configurations, Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost> action = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(rabbitMqBus =>
            {
                var host = rabbitMqBus.Host(new Uri(configurations.Uri), rabbitMqHost =>
                {
                    rabbitMqHost.Username(configurations.Username);
                    rabbitMqHost.Password(configurations.Password);
                });

                action?.Invoke(rabbitMqBus, host);
            });
        }
    }
}