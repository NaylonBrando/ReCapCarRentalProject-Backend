using Core.Entities.Concrate;
using Core.Ultilities.Results;
using Core.Ultilities.Secuirty.JWT;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);

        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IDataResult<User> Update(UserForUpdateDto userForRegisterDto, string password);

        IDataResult<User> UpdatePassword(UserForUpdatePasswordDto userForUpdatePasswordDto, string password);
        IResult UserExists(string email);

        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}