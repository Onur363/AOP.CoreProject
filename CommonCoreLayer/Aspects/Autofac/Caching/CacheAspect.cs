using Castle.DynamicProxy;
using CommonCoreLayer.CrossCuttingConcerns.Caching;
using CommonCoreLayer.Utilities.Interceptors;
using CommonCoreLayer.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using CommonCoreLayer.Utilities.Results;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Newtonsoft.Json;

namespace CommonCoreLayer.Aspects.Autofac.Caching
{
    public class CacheAspect:MethodInterception
    {
        private int duration;
        private ICacheManager cacheManager;
        public CacheAspect(int duration=60) //default 60 dk olarak verilecek
        {
            this.duration = duration;
            cacheManager=ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }
        public override void Intercept(IInvocation invocation)
        {
            //Bu çağıralan metodların isimleini alrak key değeri elde etmmeizi sağlıyor
            //invocation.Method.ReflectedType.FullName --> metodun bulunduğu calss ismi ile birlikte adını veriri.
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            //method argümanları
            var arguments = invocation.Arguments.ToList();

            //Burada metodun bulundupu kooonum ve aldığı paretmerelere göre key oluşturudk yani
            //ProductManger da GetGategoryById metodunun parametresi 10 olsun key değeri şu şekilde olacak
            //--> Productmanager.GetCategoryById(10) 
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>" ))})";

            if(cacheManager.IsAdd(key)) //bu key değerine ait cache te veri varmı
            {
                //var ise 
                invocation.ReturnValue = cacheManager.Get(key); //bunu cachten getir metodun dönüş değerine ekle
                return;
            }
            //yoksa metodu çalıştır oluşan değeri cache e at diyoruz.

            invocation.Proceed();

            cacheManager.Add(key, invocation.ReturnValue, duration);
        }
    }
}
