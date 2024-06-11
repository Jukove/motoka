using Motoka.Contracts.Dto;
using System.Threading.Tasks;

namespace Motoka.Service.Interface
{
    public interface IOrderService
    {
        void Add(OrderRequestDto requestDto);
        Task OrderAccept(OrderNotificationAcceptRequestDto acceptRequestDto);
    }
}
