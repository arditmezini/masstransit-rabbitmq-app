using MassTransit.RabbitMQ.Common.Extensions;
using Topshelf;
using Topshelf.Logging;

namespace MassTransit.RabbitMQ.WindowsService
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerExtension.ConfigureLogger();

            HostFactory.Run(x =>
            {
                x.SetServiceName("Service name");
                x.SetDisplayName("Service display name");
                x.SetDescription("Service description");

                x.RunAsLocalSystem();
                x.UseLog4Net("log4net.config", true);
                x.StartAutomatically();
                

                x.Service<GreetingServer>(ser =>
                {
                    ser.ConstructUsing(name => new GreetingServer());
                    ser.WhenStarted(sta => sta.Start());
                    ser.WhenStopped(stp => stp.Stop());
                });

                x.EnableServiceRecovery(rec =>
                {
                    rec.OnCrashOnly();
                    rec.RestartService(delayInMinutes: 0);
                    rec.RestartService(delayInMinutes: 1);

                    // Corresponds to ‘Subsequent failures: Restart the Service’
                    rec.RestartService(delayInMinutes: 5);

                    rec.SetResetPeriod(days: 1);
                });

                x.OnException((ex) =>
                {
                    var log = HostLogger.Get<Program>();
                    log.Error("Global exception", ex);
                });
            });
        }
    }
}