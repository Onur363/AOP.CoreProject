using Autofac;
using Autofac.Extras.DynamicProxy;
using CommonCoreLayer.DataAccess.Nhibernate;
using CommonCoreLayer.Utilities.Interceptors;
using CommonCoreLayer.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.DataAccess.Concrete.Nhibernate;
using Northwind.DataAccess.Concrete.Nhibernate.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<NhCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<NhUserDal>().As<IUserDal>();
            builder.RegisterType<UserManager>().As<IUserService>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            

            builder.RegisterType<SqlServerHelper>().As<NhibernateHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
                {
                    Selector=new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
