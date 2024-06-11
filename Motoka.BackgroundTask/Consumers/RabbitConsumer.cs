using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Motoka.BackgroundTask.Converter;
using Motoka.BackgroundTask.Interface;
using Motoka.Domain.IRepository;
using Motoka.Postgres.Dtos;
using Motoka.RabbitMq.Interfaces;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Motoka.BackgroundTask
{

    public class RabbitConsumer : IRabbitConsumer
    {
        private readonly IRabbitConnection _connection;       
        private readonly ILogger _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public RabbitConsumer(IRabbitConnection connection,                                
                                ILogger<RabbitConsumer> logger,
                                IServiceScopeFactory serviceScopeFactory)
        {
            _connection = connection;
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public void Start(string queueName)
        {
            if (!_connection.IsConnected)
            {
                _connection.TryConnection();
            }


            var channel = _connection.CreateModel();

            channel.QueueDeclare(queue: queueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var orderJson = JToken.Parse(message);
                var order = orderJson.ConverterToOrderDto();
                try
                {

                    _logger.LogInformation("Starting process of send order");

                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var _orderNotificationRepository = scope.ServiceProvider.GetRequiredService<IOrderNotificationRepository>();
                        var _orderRepository = scope.ServiceProvider.GetRequiredService<IOrderRepository>();
                        var _rentRepository = scope.ServiceProvider.GetRequiredService<IRentRepository>();
                        var insertOrder = _orderRepository.Add(orderJson.ConverterToOrderDto());
                        var rentList = _rentRepository.GetByDateRent(order.CreationDate);
                        rentList.ForEach(rent =>
                        {
                            if ((rent?.EndDate != null && rent?.EndDate < order.CreationDate) && _orderNotificationRepository.GetByDoc(rent.DeliveryDriverCnpj)?.Order?.Status != "ACCEPTED")
                                //rentList.Remove(rent);]
                                _orderNotificationRepository.Add(new OrderNotificationDto
                                {
                                    DeliveryDriverCnpj = rent.DeliveryDriverCnpj,
                                    OrderId = insertOrder.Id,
                                    SentDate = order.CreationDate,
                                });

                        });
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error to create order and send notification");
                    throw;
                }



                //Console.WriteLine("Received message: {0}", message);
            };

            channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer,
                                 consumerTag: string.Empty,
                                 noLocal: false,
                                 exclusive: false,
                                 arguments: null);

            //Console.WriteLine("Consumer started. Press [enter] to exit.");
            //Console.ReadLine();
        }

    }

}
