using Microsoft.AspNetCore.Http;
using Motoka.Postgres.Dtos;
using System.Threading.Tasks;

namespace Motoka.Service.Interface
{
    public interface IDeliveryDriverService
    {
        void Add(DelivererDto driverDto);
        Task SaveFile(IFormFile file, string document);
    }
}
