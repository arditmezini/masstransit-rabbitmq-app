using System;

namespace MassTransit.RabbitMQ.Common.Command.Message
{
    public class WindowsServiceCommand
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
    }
}
