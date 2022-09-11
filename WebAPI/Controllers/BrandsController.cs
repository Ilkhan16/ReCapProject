using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
    IBrandService _brandService;

    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }
    [HttpPost("add")]
    public IActionResult Add([FromForm] Brand brand)
    {
        var result = _brandService.Add(brand);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
    [HttpDelete("remove")]
    public IActionResult Remove([FromForm] Brand brand)
    {
        var result = _brandService.Delete(brand);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    [HttpPut("update")]
    public IActionResult Update([FromForm] Brand brand)
    {
        var result = _brandService.Update(brand);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    [HttpGet("getbyid")]
    public IActionResult GetById([FromForm] int id)
    {
        var result = _brandService.GetById(id);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _brandService.GetAll();
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
}