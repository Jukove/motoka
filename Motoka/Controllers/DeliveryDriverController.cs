using Microsoft.AspNetCore.Mvc;
using Motoka.Postgres.Dtos;
using Motoka.Service.Interface;

namespace Motoka.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryDriverController : Controller
    {
        public readonly ILogger _logger;
        public readonly IDeliveryDriverService _deliveryDriver;
        
        public DeliveryDriverController(IDeliveryDriverService deliveryDriver, ILogger<DeliveryDriverController> logger)
        {
            _deliveryDriver = deliveryDriver;
            _logger = logger;
        }

        [HttpPost("driver")]
        public async Task<IActionResult> DeliveryDriver([FromBody] DelivererDto delivererDto)
        {
            try
            {                
                _deliveryDriver.Add(delivererDto);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying persist information: {nameof(DeliveryDriver)}, {ex.Message}");
                throw;
            }            
        }

        [HttpPost("photo_document")]
        public async Task<IActionResult> PhotoDocument(IFormFile file, string document)
        {
            try
            {
                await _deliveryDriver.SaveFile(file, document);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying persist information: {nameof(DeliveryDriver)}, {ex.Message}");
                throw;
            }
        }
    }
}
