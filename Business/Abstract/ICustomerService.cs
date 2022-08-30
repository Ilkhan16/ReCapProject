using Entities.Concrete;
using Core.Business.Abstract;

namespace Business.Abstract;

public interface ICustomerService:IEntityServiceDal<Customer>
{
}