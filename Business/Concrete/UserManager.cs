using Business.Abstract;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;

public class UserManager : IUserService
{
    IUserDal _userDal;

    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public IResult Add(User user)
    {
        _userDal.Add(user);
        return new SuccessResult(Messages.UserAdded);
    }

    public IResult Delete(User user)
    {
        _userDal.Delete(user);
        return new SuccessResult(Messages.UserRemoved);
    }

    public IResult Update(User user)
    {
        _userDal.Update(user);
        return new SuccessResult(Messages.UserUpdated);
    }

    public IDataResult<List<User>> GetAll()
        => new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);

    public IDataResult<User> GetById(int id)
        => new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));

    public IDataResult<List<OperationClaim>> GetClaims(User user)
        => new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
   
    public IDataResult<User> GetByMail(string email)
        => new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
}
