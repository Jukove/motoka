using Motoka.Domain.Dto;
using Motoka.Domain.IRepository;
using Motoka.Postgres;
using Motoka.Postgres.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Motoka.Domain
{
    public class OrderNotificationRepository : IOrderNotificationRepository
    {

        public readonly PostgresContext _context;
        //public readonly DbSet _context;
        public OrderNotificationRepository(PostgresContext context)
        {
            _context = context;
        }

        public void Add(OrderNotificationDto order)
        {
            try
            {
                _context.Add(order);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public OrderNotificationDto GetByDoc(string doc)
        {
            var t = _context.OrderNotifications.FirstOrDefault(notif => notif.DeliveryDriverCnpj == doc);
            return _context.OrderNotifications.FirstOrDefault(notif => notif.DeliveryDriverCnpj == doc);
        }

        public OrderNotificationDto GetByDocOrder(OrderNotificatioAcceptDto  orderNotification)
        {
            return _context.OrderNotifications.FirstOrDefault(notif => notif.DeliveryDriverCnpj == orderNotification.Cnpj && notif.OrderId == orderNotification.OrderId);
        }

        public void UpdateAccept(OrderNotificationDto orderNotification)
        {
            _context.Update(orderNotification);
            _context.SaveChanges();
                
        }
        public List<OrderNotificationDto> GetAllByOrder(int orderId) =>  _context.OrderNotifications.Where(notif => notif.OrderId == orderId ).ToList();
    }
}
