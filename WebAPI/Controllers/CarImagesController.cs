using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarImagesController : ControllerBase
{
    ICarImageService _carImageService;
    public CarImagesController(ICarImageService carImageService)
    {
        _carImageService = carImageService;
    }
    [HttpPost("add")]
    public IActionResult Add([FromForm] IFormFile formFile, [FromForm] CarImage carImage)
    {
        var result = _carImageService.Add(formFile, carImage);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);

    }
    [HttpDelete("delete")]
    public IActionResult Delete(CarImage carImage)
    {
        var carDeleteImage = _carImageService.GetByImageId(carImage.Id).Data;
        var result = _carImageService.Delete(carDeleteImage);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    [HttpPut("update")]
    public IActionResult Update([FromForm] IFormFile formFile, [FromForm] CarImage carImage)
    {
        var result = _carImageService.Update(formFile, carImage);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    [HttpGet("getbycarid")]
    public IActionResult GetByCarId(int carId)
    {
        var result = _carImageService.GetByCarId(carId);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    [HttpGet("getbyimageid")]
    public IActionResult GetByImageId(int imageId)
    {
        var result = _carImageService.GetByImageId(imageId);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _carImageService.GetAll();
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}