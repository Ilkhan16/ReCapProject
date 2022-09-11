using Business.Abstract;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete;
using DataAccess.Abstract;

public class UserManager : IUserService
{
    IUserDal _userDal;

    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public IDataResult<List<OperationClaim>> GetOperationClaims(User user)
    {
        return new SuccessDataResult<List<OperationClaim>>(_userDal.GetOperationClaims(user), Messages.UserListed);
    }

    public IDataResult<User> GetByMail(string email)
    {
        return new SuccessDataResult<User>(_userDal.Get(user => user.Email ==email));
    }

    public IDataResult<User> GetById(int id)
    {
        return new SuccessDataResult<User>(_userDal.Get(user => user.Id == id), Messages.UserListed);
    }

    public IDataResult<List<User>> GetAll()
    {
        return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.UserListed);
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
}