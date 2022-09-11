using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    [HttpPost("add")]
    public IActionResult Add([FromForm] Customer customer)
    {
        var result = _customerService.Add(customer);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
    [HttpDelete("remove")]
    public IActionResult Remove([FromForm] Customer customer)
    {
        var result = _customerService.Delete(customer);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    [HttpPut("update")]
    public IActionResult Update([FromForm] Customer customer)
    {
        var result = _customerService.Update(customer);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    [HttpGet("getbyid")]
    public IActionResult GetById([FromForm] int id)
    {
        var result = _customerService.GetById(id);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _customerService.GetAll();
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
}