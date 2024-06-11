using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motoka.Contracts
{
    public class RentRangeUpdateDto
    {
        public string CNPJ { get; set; }
        public DateTime NewRange { get; set; }
    }
}
