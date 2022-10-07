using Business.Abstract;
using Business.Constans;
using Core.Aspect.Autofac.Caching;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;
[PerformanceAspect(5)]
public class CustomerManager:ICustomerService
{
    ICustomerDal _customerDal;

    public CustomerManager(ICustomerDal customerDal)
    {
        _customerDal = customerDal;
    }

    public IDataResult<List<Customer>> GetAll()
    {
        return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.CustomerListed);
    }
    [CacheAspect]
    public IDataResult<Customer> GetById(int id)
    {
        return new SuccessDataResult<Customer>(_customerDal.Get(customer => customer.Id==id), Messages.Listed);
    }

    public IResult Add(Customer customer)
    {
        _customerDal.Add(customer);
        return new SuccessResult(Messages.CustomerAdded);
    }

    public IResult Update(Customer customer)
    {
        _customerDal.Update(customer);
        return new SuccessResult(Messages.CustomerUpdated);
    }

    public IResult Delete(Customer customer)
    {
        _customerDal.Delete(customer);
        return new SuccessResult(Messages.CustomerRemoved);
    }
}