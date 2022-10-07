using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework;

public class EfRentalDal:EfEntityRepositoryBase<Rental,ReCapDB>,IRentalDal
{
    public List<RentalDetailDto> GetRentalDetails()
    {
        using (ReCapDB context = new ReCapDB())
        {
            var result = from rental in context.Rentals
                         join car in context.Cars on rental.CarId equals car.Id
                         join brand in context.Brands on car.BrandId equals brand.Id
                         join customer in context.Customers on rental.CustomerId equals customer.Id
                         join user in context.Users on customer.UserId equals user.Id
                         select new RentalDetailDto()
                         {
                             FullName = user.FirstName + " " + user.LastName,
                             BrandName = brand.BrandName + " " + car.CarName,
                             ReturnDate = Convert.ToDateTime(rental.ReturnDate),
                             RentalDate = rental.RentDate
                         };
            return result.ToList();
        }
    }
}