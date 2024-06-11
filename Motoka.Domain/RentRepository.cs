using Motoka.Domain.IRepository;
using Motoka.Postgres;
using Motoka.Postgres.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Motoka.Domain
{

    public class RentRepository : IRentRepository
    {
        public readonly PostgresContext _context;
        //public readonly DbSet _context;
        public RentRepository(PostgresContext context)
        {
            _context = context;
        }

        public void Add(RentDto rent)
        {
            _context.Add(rent);
            _context.SaveChanges();
        }

        public RentDto GetByCnpj(string cnpj)
        {
            return _context.Rent.Where(rent => rent.DeliveryDriverCnpj == cnpj).OrderByDescending(r => r.StartDate).FirstOrDefault();
        }

        public void Update(RentDto rent)
        {
            _context.Update(rent);
            _context.SaveChanges();
        }

        public List<RentDto> GetByDateRent(DateTime orderDate)
        {
            return _context.Rent.Where(rent => rent.ExpectedDate >= orderDate).ToList();
        }

    }
}
