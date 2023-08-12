using Castle.DynamicProxy;
using CommonCoreLayer.CrossCuttingConcerns.Caching;
using CommonCoreLayer.Utilities.Interceptors;
using CommonCoreLayer.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace CommonCoreLayer.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect:MethodInterception
    {
        private string pattern;
        private ICacheManager cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            this.pattern = pattern;
            cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        //OnSuccess yaazılmasının nedeni metod başarılı bir şekilde keleme sikl veya güncelleme yaptığı zaman cache tazelensin yenilensin demiş oıluyoruz.
        protected override void OnSuccess(IInvocation invocation)
        {
            cacheManager.RemoveByPattern(pattern);
        }
    }
}
