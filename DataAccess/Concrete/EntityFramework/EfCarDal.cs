using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework;

public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDB>, ICarDal
{
    public List<CarDetailDto> GetCarDetails()
    {
        using (ReCapDB context = new ReCapDB())
        {
            var result = from car in context.Cars
                join brand in context.Brands
                    on car.BrandId equals brand.BrandId
                join color in context.Colors
                    on car.ColorId equals color.ColorId

                select new CarDetailDto
                {
                    CarId = car.CarId,
                    BrandId = brand.BrandId,
                    ColorId = color.ColorId,

                    CarName = car.CarName,
                    BrandName = brand.BrandName,
                    ColorName = color.ColorName,

                    ModelYear = car.ModelYear,
                    DailyPrice = car.DailyPrice,
                    Description = car.Description,
                    ImagePath = (from m in context.CarImages where m.CarId == car.CarId select m.ImagePath).FirstOrDefault()
                };
            return result.ToList();
        }
    }

    public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
    {
        using (ReCapDB context = new ReCapDB())
        {
            var result = from car in context.Cars
                join brand in context.Brands
                    on car.BrandId equals brand.BrandId
                join color in context.Colors
                    on car.ColorId equals color.ColorId
                where brand.BrandId == brandId
                select new CarDetailDto
                {
                    CarId = car.CarId,
                    BrandName = brand.BrandName,
                    ColorName = color.ColorName,
                    ModelYear = car.ModelYear,
                    DailyPrice = car.DailyPrice,
                    BrandId = brand.BrandId,
                    CarName = car.CarName,
                    ColorId = color.ColorId,
                    Description = car.Description,
                    ImagePath = (from m in context.CarImages where m.CarId == car.CarId select m.ImagePath).FirstOrDefault()
                };
            return result.ToList();
        }
    }

    public List<CarDetailDto> GetCarDetailsByCarId(int id)
    {
        using (ReCapDB context = new ReCapDB())
        {
            var result = from car in context.Cars
                join brand in context.Brands
                    on car.BrandId equals brand.BrandId
                join color in context.Colors
                    on car.ColorId equals color.ColorId
                where car.CarId == id
                select new CarDetailDto
                {
                    CarId = car.CarId,
                    BrandName = brand.BrandName,
                    ColorName = color.ColorName,
                    ModelYear = car.ModelYear,
                    DailyPrice = car.DailyPrice,
                    BrandId = brand.BrandId,
                    CarName = car.CarName,
                    ColorId = color.ColorId,
                    Description = car.Description,
                    ImagePath = (from m in context.CarImages where m.CarId == car.CarId select m.ImagePath).FirstOrDefault()
                };
            return result.ToList();
        }
    }

    public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
    {
        using (ReCapDB context = new ReCapDB())
        {
            var result = from car in context.Cars
                join brand in context.Brands
                    on car.BrandId equals brand.BrandId
                join color in context.Colors
                    on car.ColorId equals color.ColorId
                where car.ColorId == colorId
                select new CarDetailDto
                {
                    CarId = car.CarId,
                    BrandName = brand.BrandName,
                    ColorName = color.ColorName,
                    ModelYear = car.ModelYear,
                    DailyPrice = car.DailyPrice,
                    BrandId = brand.BrandId,
                    CarName = car.CarName,
                    ColorId = color.ColorId,
                    Description = car.Description,
                    ImagePath = (from m in context.CarImages where m.CarId == car.CarId select m.ImagePath).FirstOrDefault()
                };
            return result.ToList();
        }
    }
}