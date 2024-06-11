using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motoka.Contracts.Dto
{
    public class OrderNotificationRequestDto
    {
        public int OrderId { get; set; }
        public int DeliveryDriverId { get; set; }
        public string Message { get; set; }
        public DateTime SentDate { get; set; }
    }
}
