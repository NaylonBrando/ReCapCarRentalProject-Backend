using System;
using System.Text;

namespace Core.Ultilities.Secuirty.JWT
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }

}
