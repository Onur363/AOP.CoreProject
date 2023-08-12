using CommonCoreLayer.Utilities.Results;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Business.Abstract
{
    public interface ICategoryService
    {
        IServiceResult Add(Category category);
        IServiceResult Update(Category category);
        IServiceResult Delete(Category category);

        IServiceDataResult<List<Category>> GetAll();
        IServiceDataResult<List<Category>> GetAllById(int categoryID);

    }
}
