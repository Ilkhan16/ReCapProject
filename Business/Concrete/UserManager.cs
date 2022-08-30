using Business.Abstract;
using Business.Constans;
using Core.Utilites.Results.Abstract;
using Core.Utilites.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class UserManager:IUserService
{
    IUserDal _userDal;

    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public IDataResult<List<User>> GetAll()
    {
        return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.UserListed);
    }

    public IDataResult<User> GetById(int id)
    {
        return new SuccessDataResult<User>(_userDal.Get(user => user.UserId == id));
    }

    public IResult Add(User user)
    {
        _userDal.Add(user);
        return new SuccessResult(Messages.UserAdded);
    }

    public IResult Update(User user)
    {
        _userDal.Update(user);
        return new SuccessResult(Messages.UserUpdated);
    }

    public IResult Delete(User user)
    {
        _userDal.Delete(user);
        return new SuccessResult(Messages.UserRemoved);
    }
}