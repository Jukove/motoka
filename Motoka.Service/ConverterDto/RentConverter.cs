using Motoka.Contracts;
using Motoka.Postgres.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Motoka.Service.ConverterDto
{
    public static class RentConverter
    {
        public static  RentDto ConverterToRentDto(this RentRequestDto rentRequest, ComplementRentDto complementRent)
        {
            return new RentDto
            {
                StartDate = rentRequest.StartDate,
                ExpectedDate = rentRequest.StartDate.AddDays(rentRequest.Range),
                DeliveryDriverCnpj = rentRequest.DeliveryDriverCnpj,
                VehiclePlate = complementRent.VehiclePlate,
                TotalCost = complementRent.TotalCost,
                Range = rentRequest.Range
            };
        }
    }
}
