using Core.Entities.Abstract;
using Core.Utilities.Results.Abstract;

namespace Core.Business.Abstract;

public interface IEntityServiceDal<T>where T:class,IEntity,new()
{
    IDataResult<List<T>> GetAll();
    IDataResult<T> GetById(int id);
    IResult Add(T entity);
    IResult Delete(T entity);
    IResult Update(T entity);
}