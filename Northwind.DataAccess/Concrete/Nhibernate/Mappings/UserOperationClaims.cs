using CommonCoreLayer.Entity.Concrete;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DataAccess.Concrete.Nhibernate.Mappings
{
    public class UserOperationClaims:ClassMap<UserOperationClaim>
    {
        public UserOperationClaims()
        {
            Table(@"UserOperationClaims");
            LazyLoad();
            Id(p => p.Id).Column("Id");
            Map(p => p.OperationClaimId).Column("OperationClaimId");
            Map(p => p.UserId).Column("UserId");
        }
    }
}
