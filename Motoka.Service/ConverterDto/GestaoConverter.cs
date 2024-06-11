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
    internal static class GestaoConverter
    {
        public static VehiclesDto ConverterToDb(this MotoDto moto)
        {
            return new VehiclesDto
            {
                Id = moto.Id,
                Placa = moto.Placa,
                Modelo = moto.Modelo,
                Ano = moto.Ano
            };
        }

    }
}
