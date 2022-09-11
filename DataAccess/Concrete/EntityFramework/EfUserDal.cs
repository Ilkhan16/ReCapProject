using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework;

public class EfUserDal : EfEntityRepositoryBase<User, ReCapDB>, IUserDal
{
    public List<OperationClaim> GetOperationClaims(User user)
    {
        using (var context = new ReCapDB())
        {
            var result = from operationClaim in context.OperationClaims
                join userOperationClaim in context.UserOperationClaims
                    on operationClaim.Id equals userOperationClaim.OperationClaimId
                where userOperationClaim.UserId == user.Id
                select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            return result.ToList();

        }
    }
}