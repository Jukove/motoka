using Microsoft.Extensions.Hosting;
using Motoka.BackgroundTask.Interface;
using System.Threading;
using System.Threading.Tasks;

namespace Motoka.BackgroundTask
{

    public  class RabbitConsumerTask : BackgroundService
    {
        private readonly IRabbitConsumer _consumer;
        private readonly string _queue = "ha.motoka.orders";
        public RabbitConsumerTask(IRabbitConsumer consumer)
        {
            _consumer = consumer;
        }

        protected override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _consumer.Start(_queue);
            return Task.CompletedTask;
        }
    }
}
