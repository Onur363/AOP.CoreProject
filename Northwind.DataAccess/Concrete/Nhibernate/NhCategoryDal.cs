using CommonCoreLayer.DataAccess.Nhibernate;
using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DataAccess.Concrete.Nhibernate
{
    public class NhCategoryDal : NhEntityRepositoryBase<Category>, ICategoryDal
    {
        private NhibernateHelper nhibernateHelper;
        public NhCategoryDal(NhibernateHelper nhibernateHelper) : base(nhibernateHelper)
        {
            this.nhibernateHelper = nhibernateHelper;
        }
    }
}
