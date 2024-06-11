using Microsoft.AspNetCore.Mvc;
using Motoka.Contracts;
using Motoka.Domain.IRepository;
using Motoka.Service.Interface;

namespace Motoka.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentController : Controller
    {
        public readonly ILogger _logger;
        public readonly IRentService _rentService;
        public RentController(IRentService rentService, ILogger<RentController> logger)
        {
            _rentService = rentService;
        }
        [HttpPost("rent")]
        public IActionResult Add(RentRequestDto requestDto)
        {
            try
            {
                _rentService.Add(requestDto);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("Range")]
        public IActionResult Range(RentRangeUpdateDto requestDto)
        {
            try
            {
                _rentService.UpdateRange(requestDto);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
