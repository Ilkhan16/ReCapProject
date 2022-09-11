using Core.Entities.Concrete;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Security.JWT;
using Entities.DTOs;

namespace Business.Abstract;

public interface IAuthService
{
    IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
    IDataResult<User> Login(UserForLoginDto userForLoginDto);
    IDataResult<AccessToken> CreateAccessToken(User user);
    IResult UserExists(string mail);
}