using CommonCoreLayer.DataAccess;
using CommonCoreLayer.Entity.Concrete;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework.Contexts;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context=new NorthwindContext())
            {
                var result = (from operationClaim in context.OperationClaims
                              join userOperationClaim in context.UserOperationClaims
                              on operationClaim.Id equals userOperationClaim.OperationClaimId
                              where userOperationClaim.UserId == user.Id
                              select new OperationClaim()
                              {
                                  Id = operationClaim.Id,
                                  Name = operationClaim.Name
                              });

                return result.ToList();
            }
        }
    }
}
