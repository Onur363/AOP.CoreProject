using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLayer.DataAccess.Nhibernate
{
    public abstract class NhibernateHelper:IDisposable
    {
        private static ISessionFactory sessionFactory;

        public ISessionFactory SessionFactory
        {
            get { return sessionFactory ?? (sessionFactory = InitializeFactory()); }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public abstract ISessionFactory InitializeFactory();

        public virtual ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
