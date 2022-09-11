using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController:Controller
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromForm] UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Messages);
            }
            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Messages);
        }
        [HttpPost("register")]
        public IActionResult Register([FromForm] UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Messages);
            }
            var registerresult = _authService.Register(userForRegisterDto,userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerresult.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Messages);
        }
    }
}
