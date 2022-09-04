using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class BrandManager:IBrandService
{ 
    IBrandDal _brandDal;

    public BrandManager(IBrandDal brandDal)
    {
        _brandDal = brandDal;
    }

    public IDataResult<List<Brand>> GetAll()
    {
        return new SuccessDataResult<List<Brand>>( _brandDal.GetAll(),Messages.BrandListed);
    }

    public IDataResult<Brand> GetById(int id)
    {
        return new SuccessDataResult<Brand>(_brandDal.Get(brand => brand.BrandId == id), Messages.Listed);

    }
    [ValidationAspect(typeof(BrandValidator))]
    public IResult Add(Brand brand)
    {
        _brandDal.Add(brand);
        return new SuccessResult(Messages.BrandAdded);
    }
    [ValidationAspect(typeof(BrandValidator))]
    public IResult Update(Brand brand)
    {
        _brandDal.Update(brand);
        return new SuccessResult(Messages.BrandUpdated);
    }

    public IResult Delete(Brand brand)
    {
        _brandDal.Delete(brand);
        return new SuccessResult(Messages.BrandRemoved);
    }
}