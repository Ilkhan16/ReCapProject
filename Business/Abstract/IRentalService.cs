using Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.DTOs;

namespace Business.Abstract;

public interface IRentalService
{
    IDataResult<List<Rental>> GetAll();
    IDataResult<Rental> GetById(int id);
    IResult Add(Rental rental);
    IResult Delete(Rental rental);
    IResult Update(Rental rental);
    IDataResult<List<RentalDetailDto>> GetRentalDetails();
}