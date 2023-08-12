using CommonCoreLayer.Entity.Concrete;
using CommonCoreLayer.Utilities.Results;
using Northwind.Business.Abstract;
using Northwind.Business.Constants;
using Northwind.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal userDal;
        public UserManager(IUserDal userDal)
        {
            this.userDal = userDal;
        }
        public IServiceResult Add(User user)
        {
            userDal.AddEntity(user);
            return new SuccessServiceResult(Messages.UserAdded);
        }

        public IServiceDataResult<User> GetByMail(string mail)
        {
            User user = userDal.GetEntity(u => u.Email == mail);
            return new SuccessServiceDataResult<User>(user);
        }

        public IServiceDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = userDal.GetClaims(user);
            return new SuccessServiceDataResult<List<OperationClaim>>(result);
        }
    }
}
