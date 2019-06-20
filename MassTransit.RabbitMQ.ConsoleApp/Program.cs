using MassTransit.RabbitMQ.Common.Command.Message;
using MassTransit.RabbitMQ.Common.Common;
using MassTransit.RabbitMQ.Common.Extensions;
using System;
using System.Threading.Tasks;

namespace MassTransit.RabbitMQ.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var configurations = AppSettings.RabbitMqConfigurations;
            var bus = BusCreator.Create(configurations);
            var sendToUri = new Uri($"{configurations.Uri}{configurations.WindowsServiceQueue}");

            var text = string.Empty;

            while (text != "quit")
            {
                Console.Write("Enter a message: ");
                text = Console.ReadLine();

                var message = new WindowsServiceCommand
                {
                    Id = Guid.NewGuid(),
                    Message = text,
                    DateTime = DateTime.Now
                };

                Task.Run(() => CommandExtension.SendCommand(bus, sendToUri, message));
            }
        }
    }
}