using Business.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GearsController : ControllerBase
    {
        private IGearService _gearService;

        public GearsController(IGearService gearService)
        {
            _gearService = gearService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            //Depency chain
            var result = _gearService.GetAll();
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Gear gear)
        {
            var result = _gearService.Add(gear);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Gear gear)
        {
            var result = _gearService.Delete(gear);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Gear gear)
        {
            var result = _gearService.Update(gear);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int brandId)
        {
            var result = _gearService.GetById(brandId);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}