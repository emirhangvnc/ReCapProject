using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarTypeDetailsController : ControllerBase
    {
        ICarTypeDetailService _carTypeDetailService;

        public CarTypeDetailsController(ICarTypeDetailService carTypeDetailService)
        {
            _carTypeDetailService = carTypeDetailService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            var result = _carTypeDetailService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetById(int carTypeDetailId)
        {
            var result = _carTypeDetailService.GetCarTypeDetailId(carTypeDetailId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Add(CarTypeDetail carTypeDetail)
        {
            var result = _carTypeDetailService.Add(carTypeDetail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Delete(CarTypeDetail carTypeDetail)
        {
            var result = _carTypeDetailService.Delete(carTypeDetail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(CarTypeDetail carTypeDetail)
        {
            var result = _carTypeDetailService.Update(carTypeDetail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
