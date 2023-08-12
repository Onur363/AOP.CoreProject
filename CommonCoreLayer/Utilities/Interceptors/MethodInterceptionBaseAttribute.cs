using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLayer.Utilities.Interceptors
{
    //AttributeUsage ile kullanım kuralı eklemiş olduk
    //Bu attribute un AttributeTargets ile Class ve Method ta kullanılacağını. AllowMultiple=ture ile
    //Birden fazla kullanılabileceğini belirttik

    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple =true,Inherited =true)]
    public abstract class MethodInterceptionBaseAttribute:Attribute,IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {
           
        }
    }
}
