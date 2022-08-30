using Core.Utilites.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface IColorService
{
    IDataResult<List<Color>> GetAll();
    IResult GetByColorId(int colorId);
    IResult Add(Color color);
    IResult Update(Color color);
    IResult Delete(Color color);
}