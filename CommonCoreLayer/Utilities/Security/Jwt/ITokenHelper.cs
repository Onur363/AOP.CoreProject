using CommonCoreLayer.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLayer.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        //Jwt token oluştururken user ve user a bağlı olan claim bilgilerini token a geçeceğiz
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
