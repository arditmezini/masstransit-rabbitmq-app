using MassTransit.RabbitMQ.Common.Command.Consumer;
using MassTransit.RabbitMQ.Common.Common;
using MassTransit.RabbitMQ.Common.Extensions;
using Topshelf.Logging;

namespace MassTransit.RabbitMQ.WindowsService
{
    public class GreetingServer
    {
        private readonly IBusControl bus;
        private readonly LogWriter log = HostLogger.Get<GreetingServer>();

        public GreetingServer()
        {
            var configurations = AppSettings.RabbitMqConfigurations;
            log.Info("register consumer");
            bus = BusCreator.Create(configurations, (cfg, host) =>
             {
                 cfg.ReceiveEndpoint(host, configurations.WindowsServiceQueue, e =>
                 {
                     e.Consumer<WindowsServiceConsumer>();
                 });
             });
        }

        public void Start()
        {
            log.Info("start service");
            bus.Start();
        }

        public void Stop()
        {
            log.Info("stop service");
            bus.Stop();
        }
    }
}
