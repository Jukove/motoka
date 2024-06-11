using Motoka.BackgroundTask.Converter;
using Motoka.Contracts.Dto;
using Motoka.Domain.IRepository;
using Motoka.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motoka.Service
{
    public class OrderNotificationService : IOrderNotificationService
    {
        public readonly IOrderNotificationRepository _notificationRepository;

        public OrderNotificationService(IOrderNotificationRepository orderNotificationRepository)
        {
            _notificationRepository = orderNotificationRepository;

        }

        public List<OrderNotificationResponseDto> GetAllOrder(int id)
        {
            return _notificationRepository.GetAllByOrder(id).Select(notif => notif.ConvertToOrderNotificationResponseDto()).ToList();
        }
    }
}
