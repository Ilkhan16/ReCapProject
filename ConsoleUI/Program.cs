using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main()
        {
            ReCapDB db = new ReCapDB();

            foreach (var dbd in db.Brands)
            {
                Console.WriteLine(dbd.BrandId+" "+dbd.BrandName);
            }

            //var carManager = new CarManager(new EfCarDal());
            //foreach (var ccc in carManager.GetCarsByBrandId(1))
            //{



            //    Console.WriteLine("CarId: " + ccc.CarId);
            //    Console.WriteLine("BrandId: " + ccc.BrandId);
            //    Console.WriteLine("ColorId: " + ccc.ColorId);
            //    Console.WriteLine("ModelYear: " + ccc.ModelYear);
            //    Console.WriteLine("DailyPrice: " + ccc.DailyPrice + " TL");
            //    Console.WriteLine("Description: " + ccc.Description);
            //    Console.WriteLine("*******************************************");
            //}

            //Console.ReadLine();

        }
    }
}
