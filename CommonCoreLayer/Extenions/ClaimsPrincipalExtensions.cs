using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CommonCoreLayer.Extenions
{
    //CliamPrincipla --> sistemdeki mevcut kullanıcıya karşılık gelir
    public static class ClaimsPrincipalExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimTpye)
        {
            var result = claimsPrincipal?.FindAll(claimTpye)?.Select(x => x.Value).ToList<string>();
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
