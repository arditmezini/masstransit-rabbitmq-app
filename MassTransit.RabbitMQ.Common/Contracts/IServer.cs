using System;
using System.Collections.Generic;
using System.Text;

namespace MassTransit.RabbitMQ.Common.Contracts
{
    public interface IServer
    {
        void Start();
        void Stop();
    }
}
