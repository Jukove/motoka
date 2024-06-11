using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motoka.Contracts.Dto
{
    public class OrderNotificationResponseDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string DeliveryDriverCnpj { get; set; }
        public string Message { get; set; }
        public DateTime SentDate { get; set; }
        public bool Accept { get; set; }
    }
}
