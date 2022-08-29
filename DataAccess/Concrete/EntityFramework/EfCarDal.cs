using System.Threading.Tasks.Dataflow;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,ReCapDB>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDB db=new ReCapDB())
            {
                var result =
                    from car in db.Cars
                    join bb in db.Brands 
                        on car.BrandId equals bb.BrandId
                    join co in db.Colors
                        on car.ColorId equals co.ColorId
                    select new CarDetailDto
                    {
                        Description = car.Description, BrandName = bb.BrandName, ColorName = co.ColorName,
                        DailyPrice = car.DailyPrice
                    };

                return result.ToList();
            }

        }
    }
}
