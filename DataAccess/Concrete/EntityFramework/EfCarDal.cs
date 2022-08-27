using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using var db = new ReCapDB();
            return db.Set<Car>().SingleOrDefault(filter);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>>? filter = null)
        {
            using var db = new ReCapDB();
            return filter == null ? db.Set<Car>().ToList() : db.Set<Car>().Where(filter).ToList();
        }

        public void Add(Car entity)
        {
            using var db = new ReCapDB();
            var addCar = db.Entry(entity);
            addCar.State = EntityState.Added;
            db.SaveChanges();
        }

        public void Update(Car entity)
        {
            using var db = new ReCapDB();
            var updateCar = db.Entry(entity);
            updateCar.State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Car entity)
        {
            using var db = new ReCapDB();
            var deleteCar = db.Entry(entity);
            deleteCar.State = EntityState.Deleted;
            db.SaveChanges();
        }
    }
}
