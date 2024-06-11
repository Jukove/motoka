using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motoka.Contracts
{
    public class RentRequestDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public int Range { get; set; }
        public string DeliveryDriverCnpj { get; set; }

    }
}
