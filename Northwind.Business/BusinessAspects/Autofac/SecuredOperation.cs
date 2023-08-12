using Castle.DynamicProxy;
using CommonCoreLayer.Extenions;
using CommonCoreLayer.Utilities.Interceptors;
using CommonCoreLayer.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Security.Claims;

namespace Northwind.Business.BusinessAspects.Autofac
{
    public class SecuredOperation:MethodInterception
    {
        private string[] roles;

        private IHttpContextAccessor httpContextAccessor;

        public SecuredOperation(string roles)
        {
            this.roles = roles.Split(',');
            httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var claimRoles = httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in roles)
            {
                if (claimRoles.Contains(role))
                {
                    return;
                }
            }
            throw new UnauthorizedAccessException("Bu servise erişim yetkiniz bulunmamaktadır.");
        }
    }
}
