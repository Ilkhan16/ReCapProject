using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace ConsoleUI;

class Program
{
    static void Main()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        //carManager.Add(new Car{BrandId = 8,ColorId = 9,DailyPrice = 5800,ModelYear = 2017,Description = "Escalade" });
        //carManager.Update(new Car {CarId = 10,BrandId = 1, ColorId = 1, ModelYear = 2019, DailyPrice = 3500, Description = "Brera" });
        //carManager.Delete(new Car{CarId = 1003});
        //GetCarDetails(carManager);

        //BrandManager brandManager = new BrandManager(new EfBrandDal());
        //brandManager.Add(new Brand { BrandName = "Mercedes" });
        //brandManager.Update(new Brand{BrandId = 2,BrandName = "Purple"});
        //brandManager.Delete(new Brand{BrandId = 5});

        ColorManager colorManager = new ColorManager(new EfColorDal());
        //colorManager.Add(new Color{ColorName = "White"});
        //colorManager.Update(new Color{ColorId = 2,ColorName = "Brown"});
        //colorManager.Delete(new Color{ColorId = 4});
        //ColorGetAll(colorManager);
    }

    private static void ColorGetAll(ColorManager colorManager)
    {
        foreach (var coco in colorManager.GetAll())
        {
            Console.WriteLine(coco.ColorId + " " + coco.ColorName);
        }
    }

    private static void GetCarDetails(CarManager carManager)
    {
        foreach (var car in carManager.GetCarDetails())
        {
            Console.WriteLine(car.BrandName+" / "+car.CarName + "\n" + "Color:" + car.ColorName + "\n" + "Daily Price: " + car.DailyPrice + "\n" + car.Description);
            Console.WriteLine("*****************************************");
        }
        Console.ReadLine();
    }
}