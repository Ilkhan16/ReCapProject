using Core.Business.Abstract;
using Core.Entities;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete;

namespace Core.Business.Concrete;

public class EntityServiceDal<T> : IEntityServiceDal<T> where T :class, IEntity, new()
{
    EntityServiceDal<T> _entityService;

    public EntityServiceDal(EntityServiceDal<T> entityService)
    {
        _entityService = entityService;
    }

    public IResult Add(T entity)
    {
        _entityService.Add(entity);
        return new SuccessResult();
    }

    public IResult Delete(T entity)
    {
        _entityService.Delete(entity);
        return new SuccessResult();
    }

    public IDataResult<List<T>> GetAll()
    {
        throw new NotImplementedException();
    }

    public IDataResult<T> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IResult Update(T entity)
    {
        _entityService.Update(entity);
        return new SuccessResult();
    }
}