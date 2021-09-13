using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Entities.Concrate;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindeksScoresController : ControllerBase
    {
        private IFindeksScoreService _findeksScoreService;

        public FindeksScoresController(IFindeksScoreService findeksScoreService)
        {
            _findeksScoreService = findeksScoreService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            //Depency chain
            var result = _findeksScoreService.GetAll();
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(FindeksScore findeksScore)
        {
            var result = _findeksScoreService.Add(findeksScore);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(FindeksScore findeksScore)
        {
            var result = _findeksScoreService.Delete(findeksScore);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(FindeksScore findeksScore)
        {
            var result = _findeksScoreService.Update(findeksScore);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _findeksScoreService.GetByUserId(id);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
