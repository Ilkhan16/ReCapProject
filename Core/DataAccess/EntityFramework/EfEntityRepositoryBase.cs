using Core.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework;

public class EfEntityRepositoryBase<TEntity,TContext>: IEntityRepository<TEntity> 
    where TEntity:class,IEntity, new ()
    where TContext:DbContext,new()
{
    public TEntity? Get(Expression<Func<TEntity, bool>> filter)
    {
        using var db = new TContext();
        return db.Set<TEntity>().SingleOrDefault(filter);
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
    {
        using var db = new TContext();
        return filter == null ? db.Set<TEntity>().ToList() : db.Set<TEntity>().Where(filter).ToList();
    }

    public void Add(TEntity entity)
    {
        using var db = new TContext();
        var addCar = db.Entry(entity);
        addCar.State = EntityState.Added;
        db.SaveChanges();
    }

    public void Update(TEntity entity)
    {
        using var db = new TContext();
        var updateCar = db.Entry(entity);
        updateCar.State = EntityState.Modified;
        db.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        using var db = new TContext();
        var deleteCar = db.Entry(entity);
        deleteCar.State = EntityState.Deleted;
        db.SaveChanges();
    }
}