using Microsoft.Extensions.DependencyInjection;
using Motoka.BackgroundTask.Converter;
using Motoka.Contracts.Dto;
using Motoka.Domain.IRepository;
using Motoka.RabbitMq.Interfaces;
using Motoka.Service.Interface;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System;

namespace Motoka.Service
{

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IRabbitPublisher _rabbitPublisher;
        private readonly IServiceScopeFactory _serviceScope;
        public readonly IOrderNotificationRepository _notificationRepository;


        public OrderService(IServiceScopeFactory serviceScope , IOrderRepository orderRepository, IOrderNotificationRepository orderNotificationRepository) 
        {
            _orderRepository = orderRepository;
            //_rabbitPublisher = rabbitPublisher;
            _serviceScope = serviceScope;
            _notificationRepository = orderNotificationRepository;
        }
        public void Add(OrderRequestDto requestDto)
        {
            var rabbitPublisher = _serviceScope.CreateScope().ServiceProvider.GetRequiredService<IRabbitPublisher>();
            rabbitPublisher.Publish(JToken.FromObject(requestDto).ToString(), "mqx.order", "order");
        }

        public async Task OrderAccept(OrderNotificationAcceptRequestDto acceptRequestDto)
        {
            var notification = _notificationRepository.GetByDocOrder(acceptRequestDto.ConvertToOrderNotificationDto());
            try
            {

                notification.Accept = true;
                _notificationRepository.UpdateAccept(notification);
                notification.Order.Status = acceptRequestDto.Status.ToUpper();
                _orderRepository.Update(notification.Order);


                if (notification == null)
                    throw new ArgumentException("Not Exist order notification");

            }
            catch
            {
                notification.Accept = false;
                _notificationRepository.UpdateAccept(notification);
                notification.Order.Status = "AVAILABLE";
                _orderRepository.Update(notification.Order);

                throw;
            }
        }
    }
}
