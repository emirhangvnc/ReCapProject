using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        IGenderService _genderService;

        public GendersController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            var result = _genderService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetById(int genderId)
        {
            var result = _genderService.GetGenderId(genderId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Add(Gender gender)
        {
            var result = _genderService.Add(gender);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Delete(Gender gender)
        {
            var result = _genderService.Delete(gender);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(Gender gender)
        {
            var result = _genderService.Update(gender);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
