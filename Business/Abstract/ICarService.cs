using Core.Business.Abstract;
using Core.Utilites.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface ICarService:IEntityServiceDal<Car>
{
    IDataResult<List<Car>> GetByBrandId(int brandId);
    IDataResult<List<Car>> GetByColorId(int colorId);
    IDataResult<List<CarDetailDto>> GetCarDetails();

}