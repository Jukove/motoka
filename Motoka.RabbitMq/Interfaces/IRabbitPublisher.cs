using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motoka.RabbitMq.Interfaces
{
    public interface IRabbitPublisher
    {
        void Publish(string message, string exchange, string routingKey);
    }
}
