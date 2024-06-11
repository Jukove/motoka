using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motoka.Contracts.Dto
{
    public class OrderNotificationAcceptRequestDto
    {
        public int OrderId { get; set; }
        public string Cnpj { get; set; }
        public string Status { get; set; }
    }
}
