using Motoka.Postgres.Dtos;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motoka.BackgroundTask.Converter
{
    public static class OrderConverter
    {
        public static OrderDto ConverterToOrderDto(this JToken order)
        {
            return new OrderDto
            {
                Status = order["status"].ToString(),
                CreationDate = ((DateTime)order["creationDate"]),
                Fare = ((decimal)order["fare"])
            };
        }
    }
}
