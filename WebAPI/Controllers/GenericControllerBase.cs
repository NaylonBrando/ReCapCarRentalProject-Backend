using Business.Abstract;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericControllerBase<TEntity, TService> : ControllerBase
        where TService: IServiceBase<TEntity>
        where TEntity: class, IEntity, new()
    {
        TService _tservice;

        public GenericControllerBase(TService carService)
        {
            _tservice = carService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _tservice.GetAll();
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Post(TEntity TEntity)
        {
            var result = _tservice.Add(TEntity);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int productId)
        {
            var result = _tservice.GetById(productId);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
