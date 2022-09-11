using Core.Entities.Concrete;
using Core.Utilites.Results.Abstract;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetOperationClaims(User user);
        IDataResult<User> GetByMail(string email);
        IDataResult<User> GetById(int id);
        IDataResult<List<User>> GetAll();
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
    }
}