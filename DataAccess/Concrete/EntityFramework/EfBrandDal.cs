using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using var db = new ReCapDB();
            return db.Set<Brand>().SingleOrDefault(filter);
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>>? filter = null)
        {
            using var db = new ReCapDB();
            return filter == null ? db.Set<Brand>().ToList() : db.Set<Brand>().Where(filter).ToList();
        }

        public void Add(Brand entity)
        {
            using var db = new ReCapDB();
            var addedBrand = db.Entry(entity);
            addedBrand.State = EntityState.Added;
            db.SaveChanges();
        }

        public void Update(Brand entity)
        {
            using var db = new ReCapDB();
            var updatedBrand = db.Entry(entity);
            updatedBrand.State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Brand entity)
        {
            using var db = new ReCapDB();
            var deletedBrand = db.Entry(entity);
            deletedBrand.State = EntityState.Deleted;
            db.SaveChanges();
        }
    }
}
