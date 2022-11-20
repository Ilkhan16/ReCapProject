using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class PaymentManager:IPaymentService
{
    IPaymentDal _paymentDal;


    public PaymentManager(IPaymentDal paymentDal)
    {
        _paymentDal = paymentDal;
    }

    public IDataResult<List<Payment>> GetAll()
        => new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(), Messages.PaymentListSuccess);

    public IDataResult<Payment> GetById(int paymentId)
        => new SuccessDataResult<Payment>(_paymentDal.Get(payment => payment.Id == paymentId));

    public IDataResult<List<Payment>> GetAllByCustomerId(int customerId)
        => new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(payment => payment.CustomerId == customerId));

    [ValidationAspect(typeof(PaymentValidator))]
    public IResult Add(Payment payment)
    {
        _paymentDal.Add(payment);
        return new SuccessResult(Messages.PaymentAdded);
    }

    public IResult Delete(Payment payment)
    {
        _paymentDal.Delete(payment);
        return new SuccessResult(Messages.PaymentDeleted);
    }

    [ValidationAspect(typeof(PaymentValidator))]
    public IResult Update(Payment payment)
    {
        _paymentDal.Update(payment);
        return new SuccessResult(Messages.PaymentUpdated);
    }
}