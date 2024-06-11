using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motoka.Postgres.Dtos
{
    public class VehiclesDto
    {
        public int Id { get; set; }
        public string Ano { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public bool IsAvailable { get; set; }
    }
}
