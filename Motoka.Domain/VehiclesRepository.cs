using Motoka.Domain.IRepository;
using Motoka.Postgres;
using Motoka.Postgres.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Motoka.Domain
{
    public class GestaoRepository : IVehiclesRepository
    {
        public readonly PostgresContext _context;
        //public readonly DbSet _context;
        public GestaoRepository(PostgresContext context)
        {
            _context = context;
        }

        public void Add(VehiclesDto moto)
        {
            try
            {
                var teste = _context.Add(moto);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<VehiclesDto> GetAll()
        {
            try
            {
                var teste = _context.MotoCadastro.ToList();
                return _context.MotoCadastro.ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public VehiclesDto GetByCarPlate(string plate)
        {
            try
            {
                return _context.MotoCadastro.FirstOrDefault(vehicle => vehicle.Placa == plate);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public VehiclesDto GetByIsAvalaible()
        {
            try
            {
                return _context.MotoCadastro.FirstOrDefault(vehicle => vehicle.IsAvailable == true);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void DeleteByCarPlate(string plate)
        {
            try
            {
                var vehicle = GetByCarPlate(plate);
                _context.MotoCadastro.Remove(vehicle);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
