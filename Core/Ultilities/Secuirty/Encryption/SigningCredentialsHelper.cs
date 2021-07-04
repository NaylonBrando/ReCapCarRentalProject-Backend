using Microsoft.IdentityModel.Tokens;

namespace Core.Ultilities.Secuirty.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredantials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }

}
