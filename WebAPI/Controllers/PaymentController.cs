using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpGet("add")]
    public IActionResult Add([FromForm] Payment payment)
    {
        var result=_paymentService.Add(payment);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpDelete("delete")]
    public IActionResult Delete([FromForm] Payment payment)
    {
        var result = _paymentService.Delete(payment);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPut("update")]
    public IActionResult Update([FromForm] Payment payment)
    {
        var result = _paymentService.Update(payment);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById([FromForm] int paymentId)
    {
        var result = _paymentService.GetById(paymentId);
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _paymentService.GetAll();
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("getallbycustomerid")]
    public IActionResult GetAllByCustomerId(int customerId)
    {
        var result = _paymentService.GetAllByCustomerId(customerId);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}