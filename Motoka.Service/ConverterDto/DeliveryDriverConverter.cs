using Motoka.Contracts;
using Motoka.Postgres.Dtos;

namespace Motoka.Service.ConverterDto
{
    public static class DeliveryDriverConverter
    {
        public static DeliveryDriverDto ConvertToDeliveryDriverDto(this DelivererDto driver)
        {
            return new DeliveryDriverDto
            {
                Cnpj = driver.Cnpj,
                Name = driver.Name,
                BirthDate = driver.BirthDate,
                DriverLicenseNumber = driver.DriverLicenseNumber,
                TypeCnh = driver.TypeCnh
            };
        } 
    }
}
