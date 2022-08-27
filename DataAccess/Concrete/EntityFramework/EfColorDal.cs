using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal:IColorDal
    {
        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using var db = new ReCapDB();
            return db.Set<Color>().SingleOrDefault(filter);
        }

        public List<Color> GetAll(Expression<Func<Color, bool>>? filter = null)
        {
            using var db = new ReCapDB();
            return filter == null ? db.Set<Color>().ToList() : db.Set<Color>().Where(filter).ToList();
        }

        public void Add(Color entity)
        {
            using var db = new ReCapDB();
            var addedCar = db.Entry(entity);
            addedCar.State = EntityState.Added;
            db.SaveChanges();
        }

        public void Update(Color entity)
        {
            using var db = new ReCapDB();
            var updatedCar = db.Entry(entity);
            updatedCar.State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Color entity)
        {
            using var db = new ReCapDB();
            var deletedCar = db.Entry(entity);
            deletedCar.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
