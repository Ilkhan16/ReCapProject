﻿using Business.Abstract;
using Business.Constans;
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

    public IResult GetByBrandId(int brandId)
    {
        _brandDal.GetAll(b => b.BrandId == brandId).ToList();
        return new SuccessResult(Messages.BrandListed);
    }

    public IResult Add(Brand brand)
    {
        _brandDal.Add(brand);
        return new SuccessResult(Messages.BrandAdded);
    }

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