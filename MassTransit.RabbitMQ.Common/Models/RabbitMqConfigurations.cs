namespace MassTransit.RabbitMQ.Common.Models
{
    public class RabbitMqConfigurations
    {
        public string Uri { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string WindowsServiceQueue { get; set; }
    }
}