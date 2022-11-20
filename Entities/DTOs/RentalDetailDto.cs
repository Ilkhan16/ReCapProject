using Core.Entities.Abstract;

namespace Entities.DTOs;

public class RentalDetailDto:IDto
{
    public string FullName { get; set; }
    public string BrandName { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime ReturnDate { get; set; }
}