using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motoka.Postgres.Dtos
{
    public class RentDto
    {

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Range { get; set; }
        public string VehiclePlate { get; set; }
        public string DeliveryDriverCnpj { get; set; }
        public double TotalCost { get; set; }
        public double Fine { get; set; }
        public DateTime ExpectedDate { get; set; }


        // Navigation properties
        public virtual  VehiclesDto Vehicle { get; set; }
        public virtual DelivererDto DeliveryDriver { get; set; }
    }
}
