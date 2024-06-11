using Motoka.Domain.IRepository;
using Motoka.Postgres;
using Motoka.Postgres.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace Motoka.Domain
{
    public class DeliveryDriverRepository : IDeliveryDriverRepository
    {
        public readonly PostgresContext _context;
        //public readonly DbSet _context;
        public DeliveryDriverRepository(PostgresContext context)
        {
            _context = context;
        }

        public void Add(DelivererDto deliverer)
        {
            _context.Add(deliverer);
            _context.SaveChanges();
        }

        public void UpdateImageName(string cnpj)
        {
            var entity = GetbyDoc(cnpj);
            entity.ImageName = cnpj;
            _context.Update(entity);
            _context.SaveChanges();
        }

        public DelivererDto GetbyDoc(string cnpj)
        {
            return _context.Deliverer.FirstOrDefault(e => e.Cnpj == cnpj);
        }

        public List<DelivererDto> GetByDateRent(string cnpj)
        {
            return _context.Deliverer.Where(e => e.Cnpj == cnpj).ToList();
        }
    }
}
