using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace ConsoleUI
{
    class Program
    {
        static void Main()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car{BrandId = 1,ColorId = 2,DailyPrice = 5322,ModelYear = 2017,Description = "Xc50"});
            //carManager.Update(new Car {CarId = 10,BrandId = 1, ColorId = 1, ModelYear = 2019, DailyPrice = 3500, Description = "Brera" });

            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(new Brand { BrandName = "Mercedes" });

            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add(new Color{ColorName = "Orange"});
            //colorManager.Update(new Color{ColorId = 2,ColorName = "Brown"});



            //GetCarDetails(carManager);
        }

        private static void GetCarDetails(CarManager carManager)
        {
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Brand: " + car.BrandName + "\n" + "CarName: " + car.Description + "\n" + "Color: " +
                                  car.ColorName + "\n" + "Daily Price: " + car.DailyPrice);
                Console.WriteLine("************************");
            }
            Console.ReadLine();
        }
    }
}
