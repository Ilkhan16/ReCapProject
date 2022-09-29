using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    ICarService _carService;

    public CarsController(ICarService carService)
    {
        _carService = carService;
    }
    [HttpPost("add")]
    public IActionResult Add([FromForm] Car car)
    {
        var result = _carService.Add(car);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
    [HttpDelete("remove")]
    public IActionResult Remove([FromForm] Car car)
    {
        var result = _carService.Delete(car);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    [HttpPut("update")]
    public IActionResult Update([FromForm] Car car)
    {
        var result = _carService.Update(car);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
        var result = _carService.GetById(id);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpGet("getbybrandid")]
    public IActionResult GetByBrandId(int brandId)
    {
        var result = _carService.GetByBrandId(brandId);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpGet("getbycolorid")]
    public IActionResult GetByColorId(int colorId)
    {
        var result = _carService.GetByColorId(colorId);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _carService.GetAll();
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
}