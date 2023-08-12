using CommonCoreLayer.Entity.Concrete;
using CommonCoreLayer.Utilities.Results;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Business.Abstract
{
    public interface IUserService
    {
        IServiceDataResult<List<OperationClaim>> GetClaims(User user);
        IServiceResult Add(User user);
        IServiceDataResult<User> GetByMail(string mail);
    }
}
