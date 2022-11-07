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
[PerformanceAspect(5)]
public class ColorManager:IColorService
{
    IColorDal _colorDal;

    public ColorManager(IColorDal colorDal)
    {
        _colorDal = colorDal;
    }
    [CacheAspect]
    public IDataResult<List<Color>> GetAll()
        => new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.ColorListed);

    [CacheAspect]
    public IDataResult<Color> GetById(int id)
        => new SuccessDataResult<Color>(_colorDal.Get(color => color.ColorId == id), Messages.Listed);

    [SecuredOperation("Color.all,Admin")]
    [CacheRemoveAspect("IColorService.Get")]
    public IResult Add(Color color)
    {
        _colorDal.Add(color);
        return new SuccessResult(Messages.ColorAdded);
    }

    [SecuredOperation("Color.all,Admin")]
    [CacheRemoveAspect("IColorService.Get")]
    public IResult Update(Color color)
    {
        _colorDal.Update(color);
        return new SuccessResult(Messages.ColorUpdated);
    }

    [SecuredOperation("Color.all,Admin")]
    [CacheRemoveAspect("IColorService.Get")]
    public IResult Delete(Color color)
    {
        _colorDal.Delete(color);
        return new SuccessResult(Messages.ColorRemoved);
    }
}