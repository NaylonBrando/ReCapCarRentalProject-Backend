using Core.Entities.Concrate;
using System.Collections.Generic;

namespace Core.Ultilities.Secuirty.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }

}
