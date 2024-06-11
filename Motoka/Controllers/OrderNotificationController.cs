using Microsoft.AspNetCore.Mvc;
using Motoka.Service.Interface;

namespace Motoka.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderNotificationController : Controller
    {
        public readonly IOrderNotificationService _orderNotification;
        public OrderNotificationController(IOrderNotificationService orderNotification)
        {
            _orderNotification = orderNotification;
        }
        [HttpGet("order_notification/{id}")]
        public JsonResult OrderNotification([FromRoute] int id)
        {
            return Json(_orderNotification.GetAllOrder(id));
          
        }       
    }
}
