using Motoka.Postgres.Dtos;

namespace Motoka.Domain.IRepository
{
    public interface IDeliveryDriverRepository
    {
        void Add(DelivererDto deliveryDriver);
        DelivererDto GetbyDoc(string cnpj);

        void UpdateImageName(string cnpj);
    }
}
