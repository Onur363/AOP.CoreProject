using CommonCoreLayer.Entity.Concrete;
using CommonCoreLayer.Utilities.Results;
using CommonCoreLayer.Utilities.Security.Jwt;
using Northwind.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Business.Abstract
{
    public interface IAuthService
    {
        IServiceDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        IServiceDataResult<User> Login(UserLoginDto userLoginDto);

        IServiceResult UserExists(string email);

        IServiceDataResult<AccessToken> CreateAccessToken(User user);

    }
}
