 using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motoka.Contracts
{
    public class DeliveryDriverDto
    {      
            public string Name { get; set; }
            public string Cnpj { get; set; }
            public DateTime BirthDate { get; set; }
            public string DriverLicenseNumber { get; set; }
            public List<string> TypeCnh { get; set; }

    }
}
