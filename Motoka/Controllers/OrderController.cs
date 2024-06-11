using Microsoft.AspNetCore.Mvc;
using Motoka.Contracts.Dto;
using Motoka.Service.Interface;

namespace Motoka.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        //public IOrderService _orderService;
        public IOrderService _orderService;
        public OrderController (IOrderService  orderService)
        {
            _orderService = orderService;
            //_serviceScopeFactory = serviceScopeFactory; 
        }
        [HttpPost("order")]
        public IActionResult Order(OrderRequestDto orderRequestDto)
        {

            //var service = _serviceScopeFactory.CreateScope();
            //var orderService = service.ServiceProvider.GetRequiredService<IOrderService>();
            _orderService.Add(orderRequestDto);
            return Ok();
        }

        [HttpPost("order_status")]
        public IActionResult OrderStatus(OrderNotificationAcceptRequestDto OrderStatus)
        {

            //var service = _serviceScopeFactory.CreateScope();
            //var orderService = service.ServiceProvider.GetRequiredService<IOrderService>();
            _orderService.OrderAccept(OrderStatus);
            return Ok();
        }
    }
}
