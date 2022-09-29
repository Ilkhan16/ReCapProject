using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("add")]
    public IActionResult Add([FromForm] User user)
    {
        var result = _userService.Add(user);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpDelete("remove")]
    public IActionResult Remove([FromForm] User user)
    {
        var result = _userService.Delete(user);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpPut("update")]
    public IActionResult Update([FromForm] User user)
    {
        var result = _userService.Update(user);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById([FromForm] int id)
    {
        var result = _userService.GetById(id);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpGet("getbymail")]
    public IActionResult GetByMail([FromForm] string mail)
    {
        var result = _userService.GetByMail(mail);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpGet("getoperationclaims")]
    public IActionResult GetOperationClaims([FromForm] User user)
    {
        var result = _userService.GetOperationClaims(user);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _userService.GetAll();
        if (result.Success)
        {
            var result = _userService.Update(user);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        return BadRequest(result);
    }
}