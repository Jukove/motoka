using Motoka.Contracts.Dto;
using Motoka.Postgres.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motoka.Service.ConverterDto
{
    public static class OrderConverter
    {
       public static OrderDto ConvertToOrderDto(this OrderRequestDto dto)
        {
            return new OrderDto
            {
                Status = dto.Status,
                CreationDate = dto.CreationDate,
                Fare = dto.Fare
            };
        }
    }
}
