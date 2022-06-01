using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelTypesController : ControllerBase
    {
        IFuelTypeService _fuelTypeService;

        public FuelTypesController(IFuelTypeService fuelTypeService)
        {
            _fuelTypeService = fuelTypeService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            var result = _fuelTypeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetById(int fuelTypeId)
        {
            var result = _fuelTypeService.GetFuelTypeId(fuelTypeId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Add(FuelType fuelType)
        {
            var result = _fuelTypeService.Add(fuelType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Delete(FuelType fuelType)
        {
            var result = _fuelTypeService.Delete(fuelType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(FuelType fuelType)
        {
            var result = _fuelTypeService.Update(fuelType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
