using Motoka.Postgres.Dtos;

namespace Motoka.Domain.IRepository
{
    public interface IOrderRepository
    {
        OrderDto Add(OrderDto order);
        void Update(OrderDto order);
    }
}
