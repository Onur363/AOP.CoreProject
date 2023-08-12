using CommonCoreLayer.DataAccess.Nhibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Northwind.DataAccess.Concrete.Nhibernate.Helpers
{
    public class SqlServerHelper : NhibernateHelper
    {
        public override ISessionFactory InitializeFactory()
        {
            return Fluently.Configure().Database(MsSqlConfiguration.MsSql2012
                .ConnectionString("server=(localdb)\\MSSQLLocalDB;database=Northwind;integrated security=true;")
                .ShowSql())
                .Mappings(mappings => mappings.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
                
        }
    }
}
