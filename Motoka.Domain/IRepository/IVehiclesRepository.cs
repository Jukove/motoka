using Motoka.Postgres.Dtos;
using System.Collections.Generic;

namespace Motoka.Domain.IRepository
{
    public interface IVehiclesRepository
    {
        void Add(VehiclesDto moto);
        List<VehiclesDto> GetAll();
        VehiclesDto GetByCarPlate(string plate);
        void DeleteByCarPlate(string plate);
        VehiclesDto GetByIsAvalaible();
    }
}
