using MassTransit.RabbitMQ.Common.Command.Message;
using System;
using System.Threading.Tasks;

namespace MassTransit.RabbitMQ.Common.Command.Consumer
{
    public class WindowsServiceConsumer : IConsumer<WindowsServiceCommand>
    {
        public async Task Consume(ConsumeContext<WindowsServiceCommand> context)
        {
            await Console.Out.WriteLineAsync($"{context.Message.Id},{context.Message.Message},{context.Message.DateTime}");
        }
    }
}
