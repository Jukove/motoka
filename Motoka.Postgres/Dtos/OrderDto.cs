using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motoka.Postgres.Dtos
{
    public class OrderDto
    {      
            public int Id { get; set; }
            public DateTime CreationDate { get; set; }
            public decimal Fare { get; set; }
            public string Status { get; set; }
        
    }


}
