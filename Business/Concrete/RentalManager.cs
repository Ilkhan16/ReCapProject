using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

[PerformanceAspect(5)]
public class RentalManager : IRentalService
{
    IRentalDal _rentalDal;

    public RentalManager(IRentalDal rentalDal)
    {
        _rentalDal = rentalDal;
    }

    [CacheAspect]
    public IDataResult<List<Rental>> GetAll()
        => new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);

    [CacheAspect]
    public IDataResult<Rental> GetById(int id)
        => new SuccessDataResult<Rental>(_rentalDal.Get(rental => rental.Id == id), Messages.Listed);

    [ValidationAspect(typeof(RentalValidator))]
    [CacheRemoveAspect("IRentalService.Get")]
    public IResult Add(Rental rental)
    {
        var result = BusinessRules.Run(CheckIfCarIsRental(rental),CheckIfTheVehicleIsRented(rental));
        if (result != null)
        {
            return result;
        }
        _rentalDal.Add(rental);
        return new SuccessResult(Messages.RentalAdded);
    }

    [ValidationAspect(typeof(RentalValidator))]
    [SecuredOperation("Rental.all,Admin")]
    [CacheRemoveAspect("IRentalService.Get")]
    public IResult Update(Rental rental)
    {
        _rentalDal.Update(rental);
        return new SuccessResult(Messages.RentalUpdated);
    }

    [SecuredOperation("Rental.all,Admin")]
    [CacheRemoveAspect("IRentalService.Get")]
    public IResult Delete(Rental rental)
    {
        _rentalDal.Delete(rental);
        return new SuccessResult(Messages.RentalRemoved);
    }

    [CacheAspect]
    public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        => new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentalListed);



    #region Rules
    private IResult CheckIfCarIsRental(Rental rental)
    {
        var result = _rentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate > rental.RentDate);
        if (result != null)
        {
            return new ErrorResult(Messages.RentalNotAdded);
        }

        return new SuccessResult();
    }

    private IResult CheckIfTheVehicleIsRented(Rental rental)
    {
        var result = _rentalDal.Get(r => r.CarId == rental.CarId);
        if (result!=null)
        {
            return new ErrorResult(Messages.RentalIsTheCarAlready);
        }

        return new SuccessResult();
    }
    #endregion
}
