using Business.Abstract;
using Core.Entities.Concrate;
using Core.Ultilities.Results;
using DataAccess.Abstract;
using System.Collections.Generic;

namespace Business.Concrate
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }

        public IDataResult<User> GetByMail(string email)
        {
            var result = new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
            return result;
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));
        }
    }
}