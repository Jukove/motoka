using Motoka.Contracts.Dto;
using Motoka.Domain.Dto;
using Motoka.Postgres.Dtos;


namespace Motoka.BackgroundTask.Converter
{
    public static class OrderNotificationConverter
    {
        public static OrderNotificatioAcceptDto ConvertToOrderNotificationDto( this OrderNotificationAcceptRequestDto acceptRequestDto)
        {
            return new OrderNotificatioAcceptDto()
            {
                OrderId = acceptRequestDto.OrderId,
                Cnpj = acceptRequestDto.Cnpj
            };
        }

        public static OrderNotificationResponseDto ConvertToOrderNotificationResponseDto(this OrderNotificationDto acceptRequestDto)
        {
            return new OrderNotificationResponseDto()
            {
                Id = acceptRequestDto.Id,
                OrderId = acceptRequestDto.OrderId,
                DeliveryDriverCnpj = acceptRequestDto.DeliveryDriverCnpj,
                SentDate = acceptRequestDto.SentDate,
                Message = acceptRequestDto.Message,
                Accept = acceptRequestDto.Accept
            };
        }
    }
}
