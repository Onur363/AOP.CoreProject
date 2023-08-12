using CommonCoreLayer.Entity.Concrete;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DataAccess.Concrete.Nhibernate.Mappings
{
    public class OperationClaimMap:ClassMap<OperationClaim>
    {
        public OperationClaimMap()
        {
            Table(@"OperationClaims");
            LazyLoad();
            Id(p => p.Id).Column("Id");
            Map(p => p.Name).Column("Name");
        }
    }
}
