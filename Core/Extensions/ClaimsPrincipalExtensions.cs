using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        //Bir kisinin claimlerini ararken kullanılır
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList(); //soru işareti null olabilecegini uyarmak için kullanılır
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal) //rolleri döndür
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}