using Core.Utilites.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface ICarService
{
    IDataResult<List<Car>> GetAll();
    IDataResult<List<Car>> GetByBrandId(int brandId);
    IDataResult<List<Car>> GetByColorId(int colorId);
    IDataResult<List<CarDetailDto>> GetCarDetails();
    IResult Add(Car car);
    IResult Update(Car car);
    IResult Delete(Car car);

}