using Motoka.Contracts;
using Motoka.Domain.IRepository;
using Motoka.Postgres.Dtos;
using Motoka.Service.ConverterDto;
using Motoka.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Motoka.Service
{
    public class VehiclesService : IVehiclesService
    {
        public readonly IVehiclesRepository _gestaoRepository;

        public readonly IOrderNotificationRepository _notificationRepository;
        public VehiclesService(IVehiclesRepository gestaoRepository, IOrderNotificationRepository  notificationRepository) 
        {
            _gestaoRepository = gestaoRepository;
            _notificationRepository = notificationRepository;
        }
        public string Vehicles(MotoDto moto)
        {
            try
            {
                _gestaoRepository.Add(moto.ConverterToDb());
                return "Ok";
            } 
            catch 
            {
                throw;
            } 
             
        }

        public List<VehiclesDto> Vehicles()
        {
            try
            {              
                return _gestaoRepository.GetAll();
            }
            catch
            {
                throw;
            }

        }

        public VehiclesDto Vehicles(string plate)
        {
            try
            {                
                return _gestaoRepository.GetByCarPlate(plate);
            }
            catch
            {
                throw;
            }

        }

        public string VehiclesDelete(string plate)
        {
            try
            {
                _gestaoRepository.DeleteByCarPlate(plate);
                return "Ok";
            }
            catch
            {
                throw;
            }

        }

        public List<DeliveryDriverDto> GetallByOrder(int orderId)
        {
            try
            {
                return  _notificationRepository.GetAllByOrder(orderId).Select(notif => DeliveryDriverConverter.ConvertToDeliveryDriverDto(notif.DeliveryDriver)).ToList();           
                
            }
            catch
            {
                throw;
            }

        }


    }
}
