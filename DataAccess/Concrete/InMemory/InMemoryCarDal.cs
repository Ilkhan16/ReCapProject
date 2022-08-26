﻿using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car
                {
                    CarId = 1, BrandId = 1, ColorId = 2, DailyPrice = 2000000, Description = "Tesla v8",
                    ModelYear = 2022,
                },
                new Car
                {
                    CarId = 2, BrandId = 1, ColorId = 6, DailyPrice = 230000, Description = "Honda A12",
                    ModelYear = 1997
                },
                new Car
                {
                    CarId = 3, BrandId = 2, ColorId = 2, DailyPrice = 5000000, Description = "Tesla v12",
                    ModelYear = 2022,
                },
                new Car
                {
                    CarId = 4, BrandId = 3, ColorId = 7, DailyPrice = 500000, Description = "Sofas B2", ModelYear = 2019
                },
            };

        }

    public List<Car> GetById(int id)
    {
        return _cars.Where(c => c.CarId == id).ToList();
    }

    public List<Car> GetAll()
    {
        return _cars;
    }

    public void Add(Car car)
    {
        _cars.Add(car);
    }

    public void Update(Car car)
    {
        Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
        carToUpdate.CarId = car.CarId;
        carToUpdate.BrandId = car.BrandId;
        carToUpdate.ColorId = car.ColorId;
        carToUpdate.DailyPrice = car.DailyPrice;
        carToUpdate.Description = car.Description;
        carToUpdate.ModelYear = car.ModelYear;
    }

    public void Delete(Car car)
    {
        Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
    }
}
}
