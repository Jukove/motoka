using Motoka.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motoka.Service.Interface
{
    public interface IOrderNotificationService
    {
        List<OrderNotificationResponseDto> GetAllOrder(int id);
    }
}
