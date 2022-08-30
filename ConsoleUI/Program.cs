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
        carManager.Add(new Car{BrandId = 8,ColorId = 9,DailyPrice = 0,ModelYear = 2017,CarName = "2",Description = "1" });
        //carManager.Update(new Car {CarId = 10,BrandId = 1, ColorId = 1, ModelYear = 2019, DailyPrice = 3500, Description = "Brera" });
        //carManager.Delete(new Car{CarId = 1003});
        //GetCarDetails(carManager);
        var result = carManager.GetCarDetails();
        if (result.Success)
        {
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.BrandName + " / " + car.CarName + "\n" + "Color:" + car.ColorName + "\n" + "Daily Price: " + car.DailyPrice + "\n" + car.Description);
                Console.WriteLine("*****************************************");
                Console.WriteLine(result.Messages);
            }
        }
        else
        {
            Console.WriteLine(result.Messages);
        }

        BrandManager brandManager = new BrandManager(new EfBrandDal());
        //brandManager.Add(new Brand { BrandName = "Mercedes" });
        //brandManager.Update(new Brand{BrandId = 2,BrandName = "Purple"});
        //brandManager.Delete(new Brand{BrandId = 5});

        ColorManager colorManager = new ColorManager(new EfColorDal());
        //colorManager.Add(new Color{ColorName = "Light Blue"});
        //colorManager.Update(new Color{ColorId = 2,ColorName = "Brown"});
        //colorManager.Delete(new Color{ColorId = 4});
        //ColorGetAll(colorManager);
    }

    private static void ColorGetAll(ColorManager colorManager)
    {
        foreach (var coco in colorManager.GetAll().Data)
        {
            Console.WriteLine(coco.ColorId + " " + coco.ColorName);
        }
    }

    private static void GetCarDetails(CarManager carManager)
    {
        foreach (var car in carManager.GetCarDetails().Data)
        {
            Console.WriteLine(car.BrandName+" / "+car.CarName + "\n" + "Color:" + car.ColorName + "\n" + "Daily Price: " + car.DailyPrice + "\n" + car.Description);
            Console.WriteLine("*****************************************");
        }
        Console.ReadLine();
    }
}