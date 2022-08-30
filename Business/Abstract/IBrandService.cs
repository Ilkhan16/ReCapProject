using Core.Utilites.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface IBrandService
{
    IDataResult<List<Brand>> GetAll();
    IResult GetByBrandId(int brandId);
    //IDataResult<List<Brand>> GetByBrandId(int brandId);
    IResult Add(Brand brand);
    IResult Update(Brand brand);
    IResult Delete(Brand brand);
}