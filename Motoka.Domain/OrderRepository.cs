using Motoka.Domain.IRepository;
using Motoka.Postgres;
using Motoka.Postgres.Dtos;
using System;

namespace Motoka.Domain
{
    public class OrderRepository : IOrderRepository
    {
        public readonly PostgresContext _context;
        //public readonly DbSet _context;
        public OrderRepository(PostgresContext context)
        {
            _context = context;
        }

        public OrderDto Add(OrderDto order)
        {
            try
            {
                var insert = _context.Add(order);
                _context.SaveChanges();
                return insert.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Update(OrderDto order)
        {
            _context.Update(order);
            _context.SaveChanges();
        }

    }
}
