using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
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
    [CacheAspect]
    public IDataResult<List<Brand>> GetAll()
        => new SuccessDataResult<List<Brand>>( _brandDal.GetAll(),Messages.BrandListed);

    [CacheAspect]
    public IDataResult<Brand?> GetById(int id)
        => new SuccessDataResult<Brand?>(_brandDal.Get(brand => brand.Id == id), Messages.Listed);

    [ValidationAspect(typeof(BrandValidator))]
    [SecuredOperation("Brand.all,Admin")]
    [CacheRemoveAspect("IBrandService.Get")]
    public IResult Add(Brand brand)
    {
        _brandDal.Add(brand);
        return new SuccessResult(Messages.BrandAdded);
    }
    [ValidationAspect(typeof(BrandValidator))]
    [SecuredOperation("Brand.all,Admin")]
    [CacheRemoveAspect("IBrandService.Get")]
    public IResult Update(Brand brand)
    {
        _brandDal.Update(brand);
        return new SuccessResult(Messages.BrandUpdated);
    }
    [SecuredOperation("Brand.all,Admin")]
    [CacheRemoveAspect("IBrandService.Get")]
    public IResult Delete(Brand brand)
    {
        _brandDal.Delete(brand);
        return new SuccessResult(Messages.BrandRemoved);
    }
}