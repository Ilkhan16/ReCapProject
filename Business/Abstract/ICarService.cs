using Core.Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface ICarService
{
    IDataResult<List<Car>> GetAll();
    IDataResult<Car> GetById(int id);
    IDataResult<List<Car>> GetByBrandId(int brandId);
    IDataResult<List<Car>> GetByColorId(int colorId);
    IDataResult<List<CarDetailDto>> GetCarDetails();
    IResult Add(Car car);
    IResult Delete(Car car);
    IResult Update(Car car);

}