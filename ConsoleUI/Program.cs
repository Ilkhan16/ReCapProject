﻿using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Console.WriteLine();
            foreach (var ccc in carManager.GetById(1))
            {
                Console.WriteLine("CarId: "+ ccc.CarId);
                Console.WriteLine("BrandId: "+ccc.BrandId);
                Console.WriteLine("ColorId: "+ccc.ColorId);
                Console.WriteLine("ModelYear: "+ccc.ModelYear);
                Console.WriteLine("DailyPrice: "+ccc.DailyPrice + " TL");
                Console.WriteLine("Description: "+ccc.Description);
                Console.WriteLine("*******************************************");
            }

            Console.ReadLine();

        }
    }
}