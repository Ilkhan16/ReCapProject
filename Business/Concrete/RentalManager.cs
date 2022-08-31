using Business.Abstract;
using Business.Constans;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class RentalManager:IRentalService
{ 
    IRentalDal _rentalDal;

    public RentalManager(IRentalDal rentalDal)
    {
        _rentalDal = rentalDal;
    }

    public IDataResult<List<Rental>> GetAll()
    {
        return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.RentalListed);
    }

    public IDataResult<Rental> GetById(int id)
    {
        return new SuccessDataResult<Rental>(_rentalDal.Get(rental => rental.RentalId == id), Messages.Listed);
    }

    public IResult Add(Rental rental)
    {
        var result = _rentalDal.Get(r => r.CarId==rental.CarId && r.ReturnDate == null);
        if (rental.ReturnDate==null)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);

        }
        return new ErrorResult(Messages.RentalNotAdded);
    }

    public IResult Update(Rental rental)
    {
        _rentalDal.Add(rental);
        return new SuccessResult(Messages.RentalUpdated);
    }

    public IResult Delete(Rental rental)
    {
        _rentalDal.Add(rental);
        return new SuccessResult(Messages.RentalRemoved);
    }
}