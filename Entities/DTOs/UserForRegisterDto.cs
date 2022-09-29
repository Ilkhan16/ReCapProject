using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs;

public class UserForRegisterDto:IDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    public string? Password { get; set; }
}