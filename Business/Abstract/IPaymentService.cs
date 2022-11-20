using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface IPaymentService
{
    IDataResult<List<Payment>> GetAll();
    IDataResult<Payment> GetById(int paymentId);
    IDataResult<List<Payment>> GetAllByCustomerId(int customerId);
    IResult Add(Payment payment);
    IResult Delete(Payment payment);
    IResult Update(Payment payment);

}