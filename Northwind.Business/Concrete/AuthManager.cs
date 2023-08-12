using CommonCoreLayer.Entity.Concrete;
using CommonCoreLayer.Utilities.Results;
using CommonCoreLayer.Utilities.Security.Hashing;
using CommonCoreLayer.Utilities.Security.Jwt;
using Northwind.Business.Abstract;
using Northwind.Business.Constants;
using Northwind.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService userService;
        private ITokenHelper tokenHelper;
        public AuthManager(IUserService userService,ITokenHelper tokenHelper)
        {
            this.userService = userService;
            this.tokenHelper = tokenHelper;
        }
        public IServiceDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = userService.GetClaims(user);
            var accessToken= tokenHelper.CreateToken(user, claims.Data);

            return new SuccessServiceDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IServiceDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User()
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            userService.Add(user);

            return new SuccessServiceDataResult<User>(user,Messages.UserRegistered);
        }

        public IServiceDataResult<User> Login(UserLoginDto userLoginDto)
        {
            var userToCheck = userService.GetByMail(userLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorServiceDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordhash(userLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorServiceDataResult<User>(Messages.PasswordError);
            }

            return new SuccessServiceDataResult<User>(userToCheck.Data, Messages.SuccessLogin);
        }

        public IServiceResult UserExists(string email)
        {
            var userCheck = userService.GetByMail(email);
            if (userCheck.Data != null)
            {
                return new ErrorServiceResult(Messages.UserAlreadyExists);
            }

            return new SuccessServiceResult();
        }
    }
}
