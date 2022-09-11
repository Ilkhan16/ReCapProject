using Core.Entities.Abstract;

namespace Core.Entities.Concrete;

public class UserDetailDTO:IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}