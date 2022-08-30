using Business.Abstract;
using Business.Constans;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ColorManager:IColorService
{
    IColorDal _colorDal;

    public ColorManager(IColorDal colorDal)
    {
        _colorDal = colorDal;
    }

    public IDataResult<List<Color>> GetAll()
    {
        return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.ColorListed);
    }

    public IResult GetById(int id)
    {
        _colorDal.GetAll(car => car.ColorId == id).ToList();
        return new SuccessResult(Messages.ColorListed);

    }

    public IResult Add(Color color)
    {
        _colorDal.Add(color);
        return new SuccessResult(Messages.ColorAdded);
    }

    public IResult Update(Color color)
    {
        _colorDal.Update(color);
        return new SuccessResult(Messages.ColorUpdated);
    }

    public IResult Delete(Color color)
    {
        _colorDal.Delete(color);
        return new SuccessResult(Messages.ColorRemoved);
    }
}