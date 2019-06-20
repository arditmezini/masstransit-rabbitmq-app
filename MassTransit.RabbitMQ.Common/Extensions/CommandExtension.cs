using System;

namespace MassTransit.RabbitMQ.Common.Extensions
{
    public static class CommandExtension
    {
        public static async void SendCommand<T>(IBusControl bus, Uri sendToUri, T command) where T : class
        {
            var endpoint = await bus.GetSendEndpoint(sendToUri);

            await endpoint.Send(command);
        }
    }
}