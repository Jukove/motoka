using Motoka.Postgres.Dtos;
using System;
using System.Collections.Generic;

namespace Motoka.Domain.IRepository
{
    public interface IRentRepository
    {
        void Add(RentDto rent);
        RentDto GetByCnpj(string cnpj);
        void Update(RentDto rent);
        List<RentDto> GetByDateRent(DateTime orderDate);
    }
}
