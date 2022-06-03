using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs.CarImageDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetImagesById(int carId)
        {
            var result=_carImageService.GetImagesByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetById(int imageId)
        {
            var result = _carImageService.GetByImageId(imageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Add([FromForm(Name =("image"))]IFormFile file,[FromForm]CarImageAddDto CarImageAddDto)
        {
            var result = _carImageService.Add(file, CarImageAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Delete([FromForm(Name =("Id"))] CarImageDeleteDto carImageDeleteDto)
        {
            //var carImage = _carImageService.GetByImageId(carImageDeleteDto.Id).Data;
            var result = _carImageService.Delete(carImageDeleteDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update([FromForm(Name =("Image"))] IFormFile file, [FromForm(Name =("Id"))] CarImageUpdateDto carImageUpdateDto)
        {
            var result = _carImageService.Update(file, carImageUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
