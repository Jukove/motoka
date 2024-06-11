using Motoka.Domain.IRepository;
using Motoka.RabbitMq.Interfaces;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Motoka.RabbitMq
{

    public class RabbitMQConsumer
    {
        private readonly IRabbitConnection _connection;
        private readonly IDeliveryDriverRepository _driverRepository;
        public RabbitMQConsumer(IRabbitConnection connection, IDeliveryDriverRepository driverRepository)
        {
            _connection = connection;
            _driverRepository = driverRepository;
        }

        public void Start(string queueName)
        {
            if (!_connection.IsConnected)
            {
                _connection.TryConnection();
            }

            using (var channel = _connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine("Received message: {0}", message);
                };

                channel.BasicConsume(queue: queueName,
                                     autoAck: true,
                                     consumer: consumer,
                                     consumerTag: string.Empty,
                                     noLocal: false,
                                     exclusive: false,
                                     arguments: null);

                Console.WriteLine("Consumer started. Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }

}
