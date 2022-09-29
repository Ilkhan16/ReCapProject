using Business.Abstract;
using Business.Constans;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Business;

namespace Business.Concrete;

public class CarImageManager : ICarImageService
{
    ICarImageDal _carImageDal;
    IFileHelper _fileHelper;
    public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
    {
        _carImageDal = carImageDal;
        _fileHelper = fileHelper;
    }

    public IResult Add(IFormFile formFile, CarImage carImage)
    {
        IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));
        if (result != null)
        {
            return result;
        }
        carImage.ImagePath = _fileHelper.Upload(formFile, PathConstants.ImagesPath);
        carImage.Date = DateTime.UtcNow;
        _carImageDal.Add(carImage);
        return new SuccessResult(Messages.CarImagesAdded);
    }

    public IResult Delete(CarImage carImage)
    {
        _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
        _carImageDal.Delete(carImage);
        return new SuccessResult(Messages.CarImagesRemoved);
    }

    public IResult Update(IFormFile formFile, CarImage carImage)
    {
        carImage.ImagePath = _fileHelper.Update(formFile, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);
        _carImageDal.Update(carImage);
        return new SuccessResult(Messages.CarImagesUpdated);
    }

    public IDataResult<List<CarImage>> GetByCarId(int carId)
    {
        var result = BusinessRules.Run(CheckCarImage(carId));
        if (result != null)
        {
            return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
        }
        return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
    }

    public IDataResult<CarImage> GetByImageId(int imageId)
    {
        return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == imageId));
    }

    public IDataResult<List<CarImage>> GetAll()
    {
        return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(),Messages.CarImagesListed);
    }




    //--------------------------------------Rules--------------------------------------\\
    private IResult CheckIfCarImageLimit(int carId)
    {
        var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
        if (result >= 5)
        {
            return new ErrorResult(Messages.CarImageCountExceeded);
        }
        return new SuccessResult();
    }
    private IDataResult<List<CarImage>> GetDefaultImage(int carId)
    {

        List<CarImage> carImage = new List<CarImage>();
        carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "Default.png" });
        return new SuccessDataResult<List<CarImage>>(carImage);
    }
    private IResult CheckCarImage(int carId)
    {
        var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
        if (result > 0) 
        {
            return new SuccessResult();
        }
        return new ErrorResult();
    }
}