namespace Entities.DTOs;

public class CarDetailDto
{
    public int CarId { get; set; }
    public int BrandId { get; set; }
    public int ColorId { get; set; }
    public string? CarName { get; set; }
    public string? ColorName { get; set; }
    public string? BrandName { get; set; }
    public int ModelYear { get; set; }
    public int DailyPrice { get; set; }
    public string? Description { get; set; }
}