using CommonCoreLayer.Utilities.Results;
using Northwind.Business.Abstract;
using Northwind.Business.Constants;
using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public IServiceResult Add(Category category)
        {
            categoryDal.AddEntity(category);
            return new SuccessServiceResult(Messages.CategoryAdded);
        }

        public IServiceResult Delete(Category category)
        {
            categoryDal.DeleteEntity(category);
            return new SuccessServiceResult(Messages.CategoryDeleted);
        }

        public IServiceDataResult<List<Category>> GetAll()
        {
            
            return new SuccessServiceDataResult<List<Category>>(categoryDal.GetAllEntity());
        }

        public IServiceDataResult<List<Category>> GetAllById(int categoryID)
        {
            return new SuccessServiceDataResult<List<Category>>(categoryDal.GetAllEntity(c=>c.ID==categoryID));
        }

        public IServiceResult Update(Category category)
        {
            categoryDal.UpdateEntity(category);
            return new SuccessServiceResult(Messages.CategoryUpdated);
        }
    }
}
