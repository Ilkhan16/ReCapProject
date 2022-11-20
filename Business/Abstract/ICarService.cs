using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface ICarService
{
    IDataResult<List<Car>> GetAll();
    IDataResult<List<CarDetailDto>> GetById(int id);
    IDataResult<List<CarDetailDto>> GetByBrandId(int brandId);
    IDataResult<List<CarDetailDto>> GetByColorId(int colorId);
    IDataResult<List<CarDetailDto>> GetCarDetails();
    IResult Add(Car car);
    IResult Delete(Car car);
    IResult Update(Car car);

}