using CommonCoreLayer.DataAccess.Nhibernate;
using Northwind.DataAccess.Abstract;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using CommonCoreLayer.Entity.Concrete;

namespace Northwind.DataAccess.Concrete.Nhibernate
{
    public class NhUserDal : NhEntityRepositoryBase<User>, IUserDal
    {
        private NhibernateHelper nhibernateHelper;
        public NhUserDal(NhibernateHelper nhibernateHelper) : base(nhibernateHelper)
        {
            this.nhibernateHelper = nhibernateHelper;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (var session=nhibernateHelper.OpenSession())
            {
                var result = (from operationClaim in session.Query<OperationClaim>()
                              join userOperationClaim in session.Query<UserOperationClaim>()
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
