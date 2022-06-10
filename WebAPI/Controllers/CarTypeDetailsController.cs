using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs.CarTypeDetailDto;
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
        public IActionResult Add(CarTypeDetailAddDto carTypeDetailAddDto)
        {
            var result = _carTypeDetailService.Add(carTypeDetailAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Delete(CarTypeDetailDeleteDto carTypeDetailDeleteDto)
        {
            var result = _carTypeDetailService.Delete(carTypeDetailDeleteDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(CarTypeDetailUpdateDto carTypeDetailUpdateDto)
        {
            var result = _carTypeDetailService.Update(carTypeDetailUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
