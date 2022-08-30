using Business.Abstract;
using Business.Constans;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class CarManager : ICarService
{
    ICarDal _carDal;

    public CarManager(ICarDal carDal)
    {
        _carDal = carDal;
    }

    public IDataResult<List<Car>> GetAll()
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll() ,Messages.CarsListed);
    }

    public IDataResult<Car> GetById(int id)
    {
        return new SuccessDataResult<Car>(_carDal.Get(car => car.CarId == id));
    }

    public IDataResult<List<Car>> GetByBrandId(int brandId)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(car => car.BrandId == brandId).ToList());
    }

    public IDataResult<List<Car>> GetByColorId(int colorId)
    {
        return new SuccessDataResult<List<Car>>( _carDal.GetAll(car => car.ColorId == colorId).ToList());
    }

    public IDataResult<List<CarDetailDto>> GetCarDetails()
    {
        return new SuccessDataResult<List<CarDetailDto>>( _carDal.GetCarDetails(),Messages.CarsListed);
    }

    public IResult Add(Car car)
    {
        if (car.CarName is { Length: <= 2 } && car.DailyPrice <= 0)
        {
            return new ErrorResult(Messages.CarNameInvalid);
        }
        _carDal.Add(car);
        return new SuccessResult(Messages.CarAdded);
    }

    public IResult Update(Car car)
    {
        _carDal.Update(car);
        return new SuccessResult(Messages.CarUpdated);
    }

    public IResult Delete(Car car)
    {
        _carDal.Delete(car);
        return new SuccessResult(Messages.CarRemoved);
    }
}