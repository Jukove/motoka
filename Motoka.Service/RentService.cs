using Motoka.Contracts;
using Motoka.Domain.IRepository;
using Motoka.Service.ConverterDto;
using Motoka.Service.Interface;
using System;
using System.Text.RegularExpressions;

namespace Motoka.Service
{
    public class RentService : IRentService
    {
        public readonly IRentRepository _rentRepository;
        public readonly IVehiclesRepository _gestaoRepository;
        public RentService(IRentRepository rentRepository, IVehiclesRepository gestaoRepository) 
        {
            _rentRepository = rentRepository;
            _gestaoRepository = gestaoRepository;
        }

        public void Add(RentRequestDto rent)
        {
            
            var vehicle = _gestaoRepository.GetByIsAvalaible();
            if (vehicle == null)
                throw new ArgumentNullException("Não tem veículo disponível");
            var checkDoc = CheckDoc(rent.DeliveryDriverCnpj);
            if (!checkDoc)
                throw new ArgumentException("Documento fornecido inválido");
            var complement = new ComplementRentDto
            {
                TotalCost = CalculateCost(rent.Range),
                VehiclePlate = vehicle.Placa
            };
           
            _rentRepository.Add(rent.ConverterToRentDto(complement));
        }

        public void UpdateRange(RentRangeUpdateDto request)
        {
            var currentRent = _rentRepository.GetByCnpj(request.CNPJ);
            var range = (currentRent.ExpectedDate - request.NewRange).Days;

            if ( range == 0)
                throw new ArgumentException("Não é possível alterar o período");
            var checkDoc = CheckDoc(request.CNPJ);
            if (!checkDoc)
                throw new ArgumentException("Documento fornecido inválido");

            currentRent.Fine = CalculateFine(currentRent.Range, range);
            currentRent.EndDate = request.NewRange;
            _rentRepository.Update(currentRent);
        }

        private bool CheckDoc(string doc)
        {
            if (Regex.IsMatch(doc, "[0-9]{14}"))
                return true;
            return false;
        }

        private double CalculateCost(int range)
        {
            if (range == 7)
            {
                return 7 * 30;
            }
            else if (range == 15)
            {
                return 15 * 28;
            }
            else if (range == 30)
            {

                return 30 * 22;
            }
            return 0;
        }

        private double CalculateFine(int range, int unusedDays)
        {
            if (range == 7)
            {
                return unusedDays * 30 * 0.20;
            }
            else if (range == 15)
            {
                return unusedDays * 28 * 0.40;
            }
            else if (range == 30)
            {

                return unusedDays * 22 * 0.60;
            }
            return 0;
        }
    }
}
