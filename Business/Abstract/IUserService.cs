using Core.Entities.Concrate;
using Core.Ultilities.Results;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);

        IResult Update(User user);
        IDataResult<List<OperationClaim>> GetClaims(User user);

        IDataResult<User> GetByMail(string email);

        IDataResult<User> GetById(int id);
    }
}