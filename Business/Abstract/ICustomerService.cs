using Entities.Concrete;
using Core.Utilities.Results.Abstract;

namespace Business.Abstract;

public interface ICustomerService
{
    IDataResult<List<Customer>> GetAll();
    IDataResult<Customer> GetById(int id);
    IResult Add(Customer customer);
    IResult Delete(Customer customer);
    IResult Update(Customer customer);
}