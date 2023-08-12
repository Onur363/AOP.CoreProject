using CommonCoreLayer.Entity.Concrete;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DataAccess.Concrete.Nhibernate.Mappings
{
    public class UserMap:ClassMap<User>
    {
        public UserMap()
        {
            Table(@"Users");
            LazyLoad();
            Id(p => p.Id).Column("Id");
            Map(p => p.FirstName).Column("FirstName");
            Map(p => p.Email).Column("Email");
            Map(p => p.LastName).Column("LastName");
            Map(p => p.Status).Column("Status");
            Map(p => p.PasswordHash).Column("PasswordHash");
            Map(p => p.PasswordSalt).Column("PasswordSalt");
        }
    }
}
