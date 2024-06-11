using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motoka.Domain.Dto
{
    public class OrderNotificatioAcceptDto
    {
        public int OrderId { get; set; }
        public string Cnpj { get; set; }
    }
}
