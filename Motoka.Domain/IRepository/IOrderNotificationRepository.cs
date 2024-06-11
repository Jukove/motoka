using Motoka.Domain.Dto;
using Motoka.Postgres.Dtos;
using System.Collections.Generic;

namespace Motoka.Domain.IRepository
{
    public interface IOrderNotificationRepository
    {
        void Add(OrderNotificationDto order);
        OrderNotificationDto GetByDoc(string doc);
        List<OrderNotificationDto> GetAllByOrder(int orderId);
        OrderNotificationDto GetByDocOrder(OrderNotificatioAcceptDto orderNotification);
        void UpdateAccept(OrderNotificationDto orderNotification);
    }
}
