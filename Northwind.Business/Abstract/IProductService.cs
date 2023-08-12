using CommonCoreLayer.Utilities.Results;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Business.Abstract
{
    public interface IProductService
    {
        IServiceDataResult<Product> GetByID(int productID);
        IServiceDataResult<List<Product>> GetList();
        IServiceDataResult<List<Product>> GetListByCategory(int categoryId);
        IServiceResult Add(Product product);
        IServiceResult Delete(Product product);
        IServiceResult Update(Product product);

    }
}
