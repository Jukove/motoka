using Motoka.RabbitMq.Interfaces;
using RabbitMQ.Client;
using System.Text;

namespace Motoka.RabbitMq
{
    public class RabbitPublisher : IRabbitPublisher
    {
        private readonly IRabbitConnection _connection;

        public RabbitPublisher(IRabbitConnection connection)
        {
            _connection = connection;
        }

        public void Publish(string message, string exchange, string routingKey)
        {
            if (!_connection.IsConnected)
            {
                _connection.TryConnection();
            }

            using (var channel = _connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: exchange, type: ExchangeType.Topic, durable: true);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: exchange,
                                     routingKey: routingKey,
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
