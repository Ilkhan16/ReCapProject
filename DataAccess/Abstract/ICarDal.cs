using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        List<Car> GetById(int id);
        List<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
