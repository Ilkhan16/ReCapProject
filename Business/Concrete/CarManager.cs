using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Core.Aspect.Autofac.Caching;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete;
[PerformanceAspect(5)]
public class CarManager : ICarService
{
    ICarDal _carDal;

    public CarManager(ICarDal carDal)
    {
        _carDal = carDal;
    }

    [CacheAspect]
    public IDataResult<List<Car>> GetAll()
        => new SuccessDataResult<List<Car>>(_carDal.GetAll() ,Messages.CarsListed);

    [CacheAspect]
    public IDataResult<Car> GetById(int id)
        => new SuccessDataResult<Car>(_carDal.Get(car => car.Id == id), Messages.Listed);

    [CacheAspect]
    public IDataResult<List<Car>> GetByBrandId(int brandId)
        => new SuccessDataResult<List<Car>>(_carDal.GetAll(car => car.BrandId == brandId)
                                                   .ToList(), Messages.Listed);

    [CacheAspect]
    public IDataResult<List<Car>> GetByColorId(int colorId)
        => new SuccessDataResult<List<Car>>( _carDal.GetAll(car => car.ColorId == colorId)
                                                    .ToList(), Messages.Listed);
    [CacheAspect]
    public IDataResult<List<CarDetailDto>> GetCarDetails()
        => new SuccessDataResult<List<CarDetailDto>>( _carDal.GetCarDetails(),Messages.CarsListed);

    [SecuredOperation("Car.all,Admin")]
    [TransactionScopeAspect]
    [CacheRemoveAspect("ICarService.Get")]
    [ValidationAspect(typeof(CarValidator))]
    public IResult Add(Car car)
    {
        IResult result = BusinessRules.Run(CheckIfCarNameExists(carname: car.CarName), CheckIfCarDescriptionIsNull(car));
        if (result != null)
        {
            return result;
        }
        _carDal.Add(car);
        return new SuccessResult(Messages.CarAdded);
    }

    [SecuredOperation("Car.all,Admin")]
    [TransactionScopeAspect]
    [CacheRemoveAspect("ICarService.Get")]
    [ValidationAspect(typeof(CarValidator))]
    public IResult Update(Car car)
    {
        _carDal.Update(car);
        return new SuccessResult(Messages.CarUpdated);
    }

    [SecuredOperation("Car.all,Admin")]
    [TransactionScopeAspect]
    [CacheRemoveAspect("ICarService.Get")]
    public IResult Delete(Car car)
    {
        _carDal.Delete(car);
        return new SuccessResult(Messages.CarRemoved);
    }

    #region Rules
    private IResult CheckIfCarNameExists(string carname)
    {
        var checkcar = _carDal.GetAll(car => car.CarName == carname).Any();
        if (checkcar)
        {
            return new ErrorResult(Messages.CarNameAlreadyExists);
        }

        return new SuccessResult();
    }

    private IResult CheckIfCarDescriptionIsNull(Car car)
    {
        if(car.Description==null)
        {
            car.Description = Messages.DescriptionDefault;
            return new SuccessResult();
        }
        return new SuccessResult();
    }

    #endregion

}