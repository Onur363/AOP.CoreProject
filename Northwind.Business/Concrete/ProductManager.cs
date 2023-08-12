using CommonCoreLayer.Aspects.Autofac.Caching;
using CommonCoreLayer.Aspects.Autofac.Logging;
using CommonCoreLayer.Aspects.Autofac.Performance;
using CommonCoreLayer.Aspects.Autofac.Validation;
using CommonCoreLayer.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using CommonCoreLayer.Utilities.Business;
using CommonCoreLayer.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Northwind.Business.Abstract;
using Northwind.Business.BusinessAspects.Autofac;
using Northwind.Business.Constants;
using Northwind.Business.ValidationRules.FluentValidation;
using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Northwind.Business.Concrete
{
    [SecuredOperation("Admin")]
    [LogAspect(typeof(FileLogger))]
    public class ProductManager : IProductService
    {
        private IProductDal productDal;
       
        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IServiceResult Add(Product product)
        {
           IServiceResult result=BusinessRules.Run(CheckProductName(product.Name));
            if (result != null)
            {
                return result;
            }

            productDal.AddEntity(product);
            return new SuccessServiceResult(Messages.ProductAdded); 
        }

        public IServiceResult Delete(Product product)
        {

            productDal.DeleteEntity(product);
            return new SuccessServiceResult(Messages.ProductDeleted);
        }

        public IServiceDataResult<Product> GetByID(int productID)
        {
            return new SuccessServiceDataResult<Product>(productDal.GetEntity(p => p.ID == productID));
        }


        [SecuredOperation("Product.List")]
        //[LogAspect(typeof(FileLogger))]
        [CacheAspect(10)]
        [PerformanceAspect(5)]
        
        public IServiceDataResult<List<Product>> GetList()
        {
            Thread.Sleep(5000);
            return new SuccessServiceDataResult<List<Product>>(productDal.GetAllEntity());
        }

        [CacheAspect(1)]
        public IServiceDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessServiceDataResult<List<Product>>(productDal.GetAllEntity(p => p.CategoryID == categoryId));
        }

        public IServiceResult Update(Product product)
        {
            productDal.UpdateEntity(product);
            return new SuccessServiceResult(Messages.ProductUpdated);
        }

        private IServiceResult CheckProductName(string productName)
        {
            if (productDal.GetEntity(p => p.Name == productName) != null)
            {
                return new ErrorServiceResult(Messages.ProductAlreadyExist);
            }
            return null;
        } 
    }
}
