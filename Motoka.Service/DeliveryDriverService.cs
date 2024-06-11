using Microsoft.AspNetCore.Http;
using Motoka.BackgroundTask.Converter;
using Motoka.Contracts.Dto;
using Motoka.Domain.IRepository;
using Motoka.Postgres.Dtos;
using Motoka.Service.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Motoka.Service
{

    public class DeliveryDriverService : IDeliveryDriverService
    {
        public readonly IDeliveryDriverRepository _driverRepository;
        public readonly IOrderNotificationRepository _notificationRepository;
        public DeliveryDriverService(IDeliveryDriverRepository driverRepository, IOrderNotificationRepository notificationRepository)
        {
            _driverRepository = driverRepository;
            _notificationRepository = notificationRepository;
            //_orderRepository = orderRepository;
        }

        public void Add(DelivererDto driverDto)
        {
            var checkCnh = CheckString(driverDto, new List<string> { "A", "B" });

            if (!checkCnh)
                throw new ArgumentException("Tipo de CNH fornecido é inválido");
            var checkDoc = CheckDoc(driverDto.Cnpj);
            if (!checkDoc)
                throw new ArgumentException("Documento fornecido inválido");

            _driverRepository.Add(driverDto);
        }

        public async Task SaveFile(IFormFile file, string document)
        {
            try
            {
                if (ExistEntity(document))
                {
                    _driverRepository.UpdateImageName(document);

                    var _imagePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory().ToString()).ToString(), "storage");
                    if (!File.Exists(_imagePath))
                        Directory.CreateDirectory(_imagePath);

                    var filePath = Path.Combine(_imagePath, document + Path.GetExtension(file.FileName));

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                

            }
            catch
            {
                throw;
            }
        }

        private bool ExistEntity(string doc)
        {
            var entity = _driverRepository.GetbyDoc(doc);
            if (entity == null)
                return false;
            return true;
        }

        private bool CheckDoc(string doc)
        {
            if (Regex.IsMatch(doc, "[0-9]{14}"))
                return true;
            return false;
        }

        private bool CheckString(DelivererDto driverDto, List<string> stringRequired)
        {
            foreach (var item in driverDto.TypeCnh)
            {
                if (!stringRequired.Contains(item.ToUpper()))
                {
                    return false;
                }
            }
            return true;
        }
       

    }
}
