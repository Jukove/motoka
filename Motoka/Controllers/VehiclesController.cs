using Microsoft.AspNetCore.Mvc;
using Motoka.Contracts;
using Motoka.Service.Interface;

namespace Motoka.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    
    public class VehiclesController : Controller
    {

        public readonly ILogger _logger;
        public readonly IVehiclesService _vehiclesService;
        public VehiclesController(IVehiclesService gestaoService, ILogger<VehiclesController> logger)
        {
            _vehiclesService = gestaoService;
        }
        [HttpPost("vehicles")]
        public IActionResult Vehicles(MotoDto motoDto) 
        {
            try
            {
                _vehiclesService.Vehicles(motoDto);
                return Ok(motoDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to save information: {nameof(VehiclesController)}, {ex.Message}");
                throw;
            }
           
        }

        [HttpGet("vehicles")]
        public IActionResult Vehicles()
        {
            try
            {
                return Ok(_vehiclesService.Vehicles());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while retrieving information: {nameof(VehiclesController)}, {ex.Message}");
                throw;
            }

        }

        [HttpGet("vehicles/{plate}")]
        public IActionResult Vehicles([FromRoute] string plate)
        {
            try
            {                
                return Ok(_vehiclesService.Vehicles(plate));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while retrieving information to {plate}: {nameof(VehiclesController)}, {ex.Message}");
                throw;
            }

        }


        [HttpDelete("vehicles/{plate}")]
        public IActionResult VehiclesDelete([FromRoute] string plate)
        {
            try
            {
                _vehiclesService.VehiclesDelete(plate);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while retrieving information to {plate}: {nameof(VehiclesController)}, {ex.Message}");
                throw;
            }

        }

        
    }
}
