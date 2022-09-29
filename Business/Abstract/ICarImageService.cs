using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract;

public interface ICarImageService
{
    IResult Add(IFormFile formFile, CarImage carImage);
    IResult Delete(CarImage carImage);
    IResult Update(IFormFile formFile, CarImage carImage);
    IDataResult<List<CarImage>> GetAll();
    IDataResult<List<CarImage>> GetByCarId(int carId);
    IDataResult<CarImage> GetByImageId(int imageId);
}