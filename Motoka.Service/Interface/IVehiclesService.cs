using Motoka.Contracts;
using Motoka.Postgres.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motoka.Service.Interface
{
    public interface IVehiclesService
    {
        string Vehicles(MotoDto moto);
        List<VehiclesDto> Vehicles();
        VehiclesDto Vehicles(string plate);
        string VehiclesDelete(string plate);
        List<DeliveryDriverDto> GetallByOrder(int orderId);
    }
}
